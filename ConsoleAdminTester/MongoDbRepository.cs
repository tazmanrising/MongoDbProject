using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;



namespace ConsoleAdminTester
{
    public static class MongoDbRepository
    {
        private static string _databaseConnection;
        public static string DatabaseConnection
        {
            get
            {
                if (string.IsNullOrEmpty(_databaseConnection))
                {
                    _databaseConnection = ConfigurationManager.ConnectionStrings["MongoDBConnection"].ToString();
                }
                return _databaseConnection;
            }
        }


        private static string _databaseName;
        public static string DatabaseName
        {
            get
            {
                if (string.IsNullOrEmpty(_databaseName))
                {
                    _databaseName = ConfigurationManager.AppSettings["MongoDatabase"].ToString();
                }
                return _databaseName;
            }
        }

        private static IMongoDatabase _database;
        public static IMongoDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = Client.GetDatabase(DatabaseName);
                }
                return _database;
            }
        }

        private static MongoClient _client;
        public static MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new MongoClient(DatabaseConnection);
                }
                return _client;
            }
        }



    }


}
