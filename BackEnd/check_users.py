import sys
import os

# Add the current directory to sys.path
sys.path.append(os.path.abspath(os.path.dirname(__file__)))

from app import create_app
from app.models.user import User

app = create_app()

with app.app_context():
    users = User.objects.all()
    print(f"Total Users: {len(users)}")
    for u in users:
        print(f" - {u.email}")
