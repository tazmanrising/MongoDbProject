using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using JobManager.Models;
using JobManager.DAL.MongoDBService;

namespace JobManager.DAL.MongoDBService.Stores
{
    public class UserActionStore
    {
        private static IMongoCollection<Order> collection;
        private static IMongoCollection<Order> Collection
        {
            get
            {
                if (collection == null)
                {
                    collection = MongoDBRepository.Database.GetCollection<Order>("Actions");
                }

                return collection;
            }
        }

        public static IEnumerable<Order> GetActions()
        {
            return Collection.Find(new BsonDocument()).ToEnumerable();
        }

        public static bool CreateAction(UserAction action)
        {
            throw new NotImplementedException();
        }
    }
}