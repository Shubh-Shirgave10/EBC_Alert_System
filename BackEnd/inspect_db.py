import os
import sys
from dotenv import load_dotenv
import pymongo

# Add project root to path
sys.path.append(os.path.abspath(os.path.dirname(__file__)))

def inspect_db():
    load_dotenv()
    
    mongodb_uri = os.getenv('MONGODB_URI')
    if not mongodb_uri:
        print("❌ Error: MONGODB_URI not found in .env file")
        return

    try:
        client = pymongo.MongoClient(mongodb_uri)
        
        # The app uses the 'phisheye' database as defined in app/__init__.py
        db_name = 'phisheye'
        db = client[db_name]
        
        print(f"--- Inspecting Database: {db_name} ---")
        
        # List all collections in the 'phisheye' database
        collections = db.list_collection_names()
        
        if not collections:
            print(f"No collections found in '{db_name}'. (Note: Database might be empty or still initializing)")
            
            # Show all available databases as a fallback
            all_dbs = client.list_database_names()
            print(f"\nAll available databases on this cluster: {all_dbs}")
        else:
            print(f"Found {len(collections)} collections:")
            for col_name in collections:
                count = db[col_name].count_documents({})
                print(f" - {col_name}: {count} documents")
                
                # If there are items, show the first one as a sample
                if count > 0:
                    sample = db[col_name].find_one()
                    # Clean up sample for printing (remove sensitive/long data if needed)
                    if 'password_hash' in sample: sample['password_hash'] = '[HIDDEN]'
                    print(f"   Sample: {sample}")

    except Exception as e:
        print(f"❌ Error: {e}")

if __name__ == "__main__":
    inspect_db()
