import os
import sys

# Add BackEnd to path
backend_path = os.path.abspath('BackEnd')
sys.path.append(backend_path)

print(f"Testing imports from {backend_path}...")

try:
    from app import create_app
    print("✅ app.create_app imported")
    
    from app.models.user import User
    print("✅ User model imported")
    
    from app.models.scan import Scan
    print("✅ Scan model imported")
    
    from app.services.scan_service import ScanService
    print("✅ ScanService imported")
    
    from app.routes.scan import scan_bp
    print("✅ scan_bp imported")
    
except Exception as e:
    print(f"❌ Import failed: {e}")
    import traceback
    traceback.print_exc()
