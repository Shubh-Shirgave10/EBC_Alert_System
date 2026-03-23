import os
import pymongo
from dotenv import load_dotenv

load_dotenv('BackEnd/.env')
uri = os.getenv('MONGODB_URI')
client = pymongo.MongoClient(uri, serverSelectionTimeoutMS=5000)

try:
    db = client.get_default_database()
    users_coll = db['users']
    users = list(users_coll.find({}, {'email': 1, 'phone': 1}))
    print(f"Managed to connect! Total Users: {len(users)}")
    for u in users:
        print(f"Email: {u.get('email')}, Phone: {u.get('phone')}")
except Exception as e:
    print(f"Failed: {e}")
finally:
    client.close()
