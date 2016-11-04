using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Stores.MongoDBStores
{
    public static class MongoDBRepository
    {
        private static string databaseConnection;
        public static string DatabaseConnection
        {
            get
            {
                if (string.IsNullOrEmpty(databaseConnection))
                {
                    databaseConnection = ConfigurationManager.ConnectionStrings["MongoDBConnection"].ToString();
                }
                return databaseConnection;
            }
        }


        private static string databaseName;
        public static string DatabaseName
        {
            get
            {
                if (string.IsNullOrEmpty(databaseName))
                {
                    databaseName = ConfigurationManager.AppSettings["MongoDatabase"].ToString();
                }
                return databaseName;
            }
        }
        private static IMongoDatabase database;
        public static IMongoDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = Client.GetDatabase(DatabaseName);
                }
                return database;
            }
        }

        private static MongoClient client;
        public static MongoClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new MongoClient(DatabaseConnection);
                }
                return client;
            }
        }

    }
}