import os
import sys
from dotenv import load_dotenv
from mongoengine import connect
import pymongo

# Add project root to path
sys.path.append(os.path.abspath(os.path.dirname(__file__)))

def test_connection():
    load_dotenv()
    
    mongodb_uri = os.getenv('MONGODB_URI')
    if not mongodb_uri:
        print("❌ Error: MONGODB_URI not found in .env file")
        return

    print(f"--- Database Connection Test ---")
    print(f"Connecting to MongoDB...")
    
    try:
        # We'll use the raw pymongo client for a quick ping test
        client = pymongo.MongoClient(mongodb_uri, serverSelectionTimeoutMS=5000)
        
        # The 'ping' command is cheap and does not require auth for most clusters
        client.admin.command('ping')
        print("✅ Success: Raw connection (PyMongo) established and pinged successfully.")
        
        # Test MongoEngine connection (which the app actually uses)
        print("Testing MongoEngine connection...")
        connect(host=mongodb_uri)
        print("✅ Success: MongoEngine connected successfully.")
        
        # List databases to confirm access
        dbs = client.list_database_names()
        print(f"Available Databases: {dbs}")
        
    except pymongo.errors.ServerSelectionTimeoutError:
        print("❌ Error: Connection timed out. This usually means:")
        print("   1. Your IP address is not whitelisted in MongoDB Atlas.")
        print("   2. Your firewall/network is blocking the connection.")
        print("   3. The connection string is incorrect.")
    except Exception as e:
        print(f"❌ Error: An unexpected error occurred: {e}")

if __name__ == "__main__":
    test_connection()
