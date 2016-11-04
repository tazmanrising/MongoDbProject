using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleAdminTester
{
    public class OrdersStore
    {
        private static IMongoCollection<Order> _collection;
        private static IMongoCollection<Order> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = MongoDbRepository.Database.GetCollection<Order>("Orders");
                }

                return _collection;
            }
        }

        public static IEnumerable<Order> GetOrders()
        {
            return Collection.Find(new BsonDocument()).ToEnumerable();
        }
    }
}
