using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobManager.DAL.MongoDBService;
using JobManager.Models;
using MongoDB.Driver;

namespace JobManager.Services
{
    public class PurchaseOrderService
    {

        private static IMongoCollection<PurchaseOrder> _collection;

        private static IMongoCollection<PurchaseOrder> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = MongoDBRepository.Database.GetCollection<PurchaseOrder>("PurchaseOrders");

                }

                return _collection;
            }
        }

        public static IEnumerable<PurchaseOrder> GetAllPurchaseOrders()
        {
            return null;
        }

        public static IEnumerable<Job> GetAllPurchaseOrders(string id)
        {
            //return JobStore.GetAllPurchaseOrders(id);
            return null;

        }
    }

}