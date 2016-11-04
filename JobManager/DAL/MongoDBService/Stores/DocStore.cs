using System.Configuration;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using JobManager.DAL.MongoDBService;

namespace JobManager.DAL.MongoDBService.Stores
{
    public static class DocStore
    {

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

        public static string GetAllDocuments()
        {
            var filter = new BsonDocument();
            var output = new List<string>();
            var cursor = Collection.Find(filter).ToList().ToJson();

            return cursor;
        }

    }
}