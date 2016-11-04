using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace JobManager.DAL.MongoDBService.Stores
{
    public static class CollectionsStore
    {
        public static string  GetCollections()
        {
            var collections = MongoDBRepository.Database.ListCollections().ToList().ToJson();
            return collections;
        }
    }
}