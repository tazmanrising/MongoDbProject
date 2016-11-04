using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Stores.MongoDBStores
{
    public static class DocStore
    {

        private static MongoClient _client = null;
        private static MongoClient Client {
            get
            {
                if (_client == null)
                { 
                    _client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDBConnection"].ConnectionString);
                }
                return _client;
            }
        }

        private static IMongoCollection<BsonDocument> collection;
        private static IMongoCollection<BsonDocument> Collection
        {
            get
            {
                if (collection == null)
                {
                    collection = MongoDBRepository.Database.GetCollection<BsonDocument>("Sample");
                }

                return collection;
            }
        }

        public static string Save()
        {
            Collection.InsertOne(new BsonDocument());
            return "successs";
        }
    }
}