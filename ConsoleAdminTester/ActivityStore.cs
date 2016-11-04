using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleAdminTester
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
                    _collection = MongoDbRepository.Database.GetCollection<Activity>("Activities");

                }

                return _collection;
            }
        }


        public static IEnumerable<Activity> GetActivities()
        {
            return Collection.Find(new BsonDocument()).ToEnumerable();
        }


        public static IEnumerable<Activity> GetActivitiesByOrderNumber(string orderNumber)
        {

            IEnumerable<Activity> activity = Collection.Find<Activity>(o => o.OrderNumber == orderNumber).ToList();
            return activity;
        }


        public static string Save(Activity activity)
        {
            Activity newActivity = Collection.Find<Activity>(o => o.Id == activity.Id).SingleOrDefault<Activity>();
            if (newActivity == null)
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

        // todo:  create Update and Create methods INSTEAD OF SAVE and Service Layer will handle this



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
