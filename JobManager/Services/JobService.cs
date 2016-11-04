using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobManager.DAL.MongoDBService;
using JobManager.DAL.MongoDBService.Stores;
using JobManager.Models;
using MongoDB.Driver;

namespace JobManager.Services
{
    public class JobService
    {
        private static IMongoCollection<Job> _collection;

        private static IMongoCollection<Job> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = MongoDBRepository.Database.GetCollection<Job>("Jobs");

                }

                return _collection;
            }
        }

        public static IEnumerable<Job> GetAllJobs()
        {
            return null;
        }

        public static IEnumerable<Job> GetAllJobOrders(string id)
        {
            //return JobStore.GetAllJobOrders(id);
            return null;

        } 

    }

}