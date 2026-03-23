from flask import Flask, jsonify, redirect
from flask_jwt_extended import JWTManager, jwt_required, get_jwt_identity
from flask_cors import CORS
from flask_limiter import Limiter
from flask_limiter.util import get_remote_address
from flask_talisman import Talisman
from flask_marshmallow import Marshmallow
import mongoengine
import os
import datetime
from dotenv import load_dotenv

load_dotenv()

jwt = JWTManager()
ma = Marshmallow()
limiter = Limiter(key_func=get_remote_address, default_limits=["200 per day", "50 per hour"])

# Proxy object so models can do: from .. import db
class _MongoProxy:
    """Thin proxy that exposes mongoengine's Document and field types."""
    Document = mongoengine.Document
    StringField = mongoengine.StringField
    IntField = mongoengine.IntField
    FloatField = mongoengine.FloatField
    BooleanField = mongoengine.BooleanField
    DateTimeField = mongoengine.DateTimeField
    ListField = mongoengine.ListField
    ReferenceField = mongoengine.ReferenceField
    EmbeddedDocumentField = mongoengine.EmbeddedDocumentField

db = _MongoProxy()

def create_app():
    BASE_DIR = os.path.abspath(os.path.dirname(__file__))
    FRONTEND_DIR = os.path.abspath(os.path.join(BASE_DIR, '..', '..', 'FrontEnd'))
    
    app = Flask(__name__, static_folder=FRONTEND_DIR, static_url_path='')
    
    # JWT Config
    app.config['JWT_SECRET_KEY'] = os.getenv('JWT_SECRET_KEY', 'phish-eye-secret-key')
    app.config['JWT_ACCESS_TOKEN_EXPIRES'] = datetime.timedelta(days=7)

    # Connect to MongoDB Atlas
    mongodb_uri = os.getenv('MONGODB_URI', 'mongodb://localhost:27017/phisheye')
    # If the URI already includes a DB name (common in Atlas strings), db=... is redundant but safe
    mongoengine.connect(host=mongodb_uri)

    # Extensions
    CORS(app, resources={r"/api/*": {"origins": "*"}})
    jwt.init_app(app)
    ma.init_app(app)
    limiter.init_app(app)
    
    # Talisman for security headers - disabled force_https for dev/local network testing
    is_prod = os.getenv('FLASK_ENV') == 'production' or os.getenv('RENDER') is not None
    Talisman(app, content_security_policy=None, force_https=is_prod)
    
    with app.app_context():
        # Import models to register them with mongoengine
        from .models.user import User
        from .models.scan import Scan
        from .models.extension import Extension
        from .models.api_key import APIKey
        
        # Register blueprints
        from .routes.auth import auth_bp
        from .routes.scan import scan_bp
        from .routes.extension import extension_bp
        from .routes.admin import admin_bp
        from .routes.otp import otp_bp
        
        app.register_blueprint(auth_bp, url_prefix='/api/auth')
        app.register_blueprint(scan_bp, url_prefix='/api/scan-logic')
        app.register_blueprint(extension_bp, url_prefix='/api/extension')
        app.register_blueprint(admin_bp, url_prefix='/api/admin')
        app.register_blueprint(otp_bp, url_prefix='/api/otp')

        # Compatibility for old /api/scan route
        from .routes.scan import scan as scan_view
        app.add_url_rule('/api/scan', 'legacy_scan', scan_view, methods=['POST'])

        @app.route('/api/history', methods=['GET'])
        @jwt_required()
        def legacy_history():
            user_id = get_jwt_identity()
            scans = Scan.objects(user_id=user_id).order_by('-created_at').limit(50)
            history_data = [{
                "id": str(s.id),
                "url": s.url,
                "result": s.result,
                "confidence": s.confidence,
                "risk_score": s.risk_score,
                "created_at": s.created_at.isoformat()
            } for s in scans]
            return jsonify({"history": history_data}), 200

        # --- CLEAN URL ROUTES ---
        @app.route('/login')
        def login_pretty():
            return app.send_static_file('login-page/login.html')

        @app.route('/dashboard')
        @app.route('/main')
        def dashboard_pretty():
            return app.send_static_file('Main_Dash/mainDash.html')

        @app.route('/home')
        def home_pretty():
            return app.send_static_file('Dashboard/dashboard.html')

        @app.route('/quickscan')
        def quickscan_pretty():
            return app.send_static_file('QuickScan/quickscan.html')

        @app.route('/history')
        def history_pretty():
            return app.send_static_file('History/history.html')

        @app.route('/settings')
        def settings_pretty():
            return app.send_static_file('setting/settings.html')

        @app.route('/about')
        def about_pretty():
            return app.send_static_file('about/about.html')

        @app.route('/')
        def index():
            return redirect('/home')

        @app.route('/<path:path>')
        def serve_static_clean(path):
            full_path = os.path.join(app.static_folder, path)
            if os.path.isfile(full_path):
                return app.send_static_file(path)

            if '.' not in path:
                potential_html = [
                    f"{path}.html",
                    f"login-page/{path}.html",
                    f"Main_Dash/{path}.html",
                    f"Dashboard/{path}.html",
                    f"History/{path}.html",
                    f"QuickScan/{path}.html",
                    f"setting/{path}.html",
                    f"about/{path}.html"
                ]
                for p in potential_html:
                    if os.path.isfile(os.path.join(app.static_folder, p)):
                        return app.send_static_file(p)

            sub_dirs = ['login-page', 'Main_Dash', 'Dashboard', 'History', 'QuickScan', 'setting', 'about']
            for sd in sub_dirs:
                potential_resource = f"{sd}/{path}"
                if os.path.isfile(os.path.join(app.static_folder, potential_resource)):
                    return app.send_static_file(potential_resource)
            
            if path.endswith(('.css', '.js', '.png', '.jpg', '.jpeg', '.svg', '.gif', '.ico')):
                return jsonify({"error": "Resource not found"}), 404

            return redirect('/home')

    return app
