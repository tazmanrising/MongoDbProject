using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using JobManager.Controllers.APIs;
using MongoDB.Driver;
using MongoDB.Bson;
using JobManager.DAL.MongoDBService;
using JobManager.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace JobManager.DAL.MongoDBService.Stores
{
    public static class ActivityStore
    {

        private static IMongoCollection<Activity> _collection;

        private static IMongoCollection<Activity> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = MongoDBRepository.Database.GetCollection<Activity>("Activities");
                    
                }

                return _collection;
            }
        }


        public static IEnumerable<Activity> GetActivities()
        {
            return Collection.Find(new BsonDocument()).ToEnumerable();
        }


        public static Activity GetActivityById(string activityid)
        {
            //ObjectId id = new ObjectId(activityid);
            //Activity activity = Collection.Find<Activity>(o => o.Id == id).FirstOrDefault();
            return null; // activity;
        }

        public static IEnumerable<Activity> GetActivitiesByClientShortCode(string shortCode)
        {
            return Collection.Find<Activity>(o => o.ClientShortCode == shortCode).ToList();
        }
        public static IEnumerable<Activity> GetActivitiesByOrderNumber(List<OrderStuff> orderNumber)
        {

            //IEnumerable<Activity> activity = Collection.Find<Activity>(o => o.OrderNumber == orderNumber).ToList();


            //List<string> listOfValues = new List<string>();
            //var set = new HashSet<string>(listOfValues.Select(y => y[0]));

            //IEnumerable<Activity> activity = Collection.Find(orderNumber.Where(s => orderNumber.Any(a => a[0] == s)));

           var OrderStuffIds = orderNumber.Select(o => o.id);

            IEnumerable<Activity> activities = Collection.Find(a => OrderStuffIds.Contains(a.OrderNumber)).ToList();
            return activities;

        }

       
        public static string Save(Activity activity)
        {
            Activity newOrder = Collection.Find<Activity>(o => o.Id == activity.Id).SingleOrDefault<Activity>();
            if (newOrder == null)
            {
                activity.Status = "Created";
                Collection.InsertOne(activity);
                return activity.ToJson();
            }
            else
            {
                var filter = Builders<Activity>.Filter.Eq("id", activity.Id);
                Collection.ReplaceOne<Activity>(o => o.Id == activity.Id, activity, new UpdateOptions { IsUpsert = true });
                return activity.ToJson();
            }
        }


        public static string Create(Activity activity)
        {
            Collection.InsertOne(activity);
            return activity.ToJson();

        }

        public static string Update(Activity activity)
        {
            var filter = Builders<Activity>.Filter.Eq("id", activity.Id);
            Collection.ReplaceOne<Activity>(o => o.Id == activity.Id, activity, new UpdateOptions { IsUpsert = true });
            return activity.ToJson();
        }


        public static bool Delete(string entityId)
        {
            ObjectId id = new ObjectId(entityId);
            
            //TODO:  refactor for async/await

            var filter = new BsonDocument("_id", id);
            var result = Collection.DeleteOne(filter);

            return true;
        }


    }



}