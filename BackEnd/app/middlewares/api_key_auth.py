from functools import wraps
from flask import request, jsonify
from ..models.api_key import APIKey
from ..models.user import User
from datetime import datetime

def require_api_key(f):
    @wraps(f)
    def decorated_function(*args, **kwargs):
        api_key_value = request.headers.get('X-API-KEY')
        if not api_key_value:
            return jsonify({"message": "API key is missing"}), 401
        
        key_record = APIKey.objects(key_value=api_key_value, is_active=True).first()
        if not key_record:
            return jsonify({"message": "Invalid or inactive API key"}), 403
        
        # Update last used
        key_record.last_used = datetime.utcnow()
        key_record.save()
        
        # Attach user to request for convenience
        request.api_user_id = key_record.user_id
        return f(*args, **kwargs)
    return decorated_function
