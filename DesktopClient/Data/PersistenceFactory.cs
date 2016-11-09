using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public static class PersistenceFactory
    {
        public static IMongoDatabase _database;

        public static IMongoDatabase GetDatabase()
        {
            if(_database == null)
            {
                IMongoClient client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString);
                _database = client.GetDatabase(ConfigurationManager.AppSettings.Get("MongoDbName"));
            }

            return _database;
        }
    }
}
