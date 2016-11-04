using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using JobManager.Models;
using JobManager.DAL.MongoDBService;

namespace JobManager.DAL.MongoDBService.Stores
{
    public class OrdersStore
    {
        private static IMongoCollection<Order> collection;
        private static IMongoCollection<Order> Collection
        {
            get
            {
                if (collection == null)
                {
                    collection = MongoDBRepository.Database.GetCollection<Order>("Orders");
                }

                return collection;
            }
        }

        public static IEnumerable<Order> GetOrders()
        {
            return Collection.Find(new BsonDocument()).ToEnumerable();
        }

        public static Order GetOrderById(string orderId)
        {
            //ObjectId id = new ObjectId(orderId);
            //Order order = Collection.Find<Order>(o => o.Id == id).FirstOrDefault();

            Order order = Collection.Find<Order>(o => o.Id == orderId).FirstOrDefault();
            return order;

        }

        public static Order GetOrderByNumber(string orderNumber)
        {
            Order order = Collection.Find<Order>(o => o.OrderNumber == orderNumber).FirstOrDefault();
            return order;
        }

        public static IEnumerable<Order> GetOrdersByClientShortCode(string shortCode)
        {
            return Collection.Find<Order>(o => o.ClientShortCode == shortCode).ToList();
        }


        public static IEnumerable<Order> GetOrderByAssigned()
        {
            //return collection.MapReduceAsync()

            return Collection.Find<Order>(o => o.AssignedToName != null).ToList();

        }

        public static IEnumerable<Order> GetOrderByUnAssigned()
        {
            return Collection.Find<Order>(o => o.AssignedToName == null).ToList();

        }

        public static string GetOrdersByClientShortCodeJSON(string shortCode)
        {
            return Collection.Find<Order>(o => o.ClientShortCode == shortCode).ToList().ToJson();
        }

        public static string Save(Order order)
        {
            Order newOrder = Collection.Find<Order>(o => o.Id == order.Id).SingleOrDefault<Order>();
            if (newOrder == null)
            {
                Collection.InsertOne(order);
                return order.ToJson();
            }
            else
            {
                var filter = Builders<Order>.Filter.Eq("id", order.Id);
                Collection.ReplaceOne<Order>(o=>o.Id == order.Id, order, new UpdateOptions { IsUpsert = true } );
                return order.ToJson();
            }
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