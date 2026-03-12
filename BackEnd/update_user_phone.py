import sys
import os

# Add the current directory to sys.path
sys.path.append(os.path.abspath(os.path.dirname(__file__)))

from app import create_app
from app.models.user import User

app = create_app()

with app.app_context():
    email = 'yashnaik459@gmail.com'
    phone = '+919945576085'
    
    # Check if user exists
    user = User.objects(email=email).first()
    if not user:
        # Create user if they don't exist
        user = User(email=email, phone=phone)
        user.set_password('password123')
        user.save()
        print(f"Created new user {user.email}")
    else:
        # Update phone if user exists
        user.phone = phone
        user.save()
        print(f"Updated phone for existing user {user.email}")
        
    print("Database updated!")
