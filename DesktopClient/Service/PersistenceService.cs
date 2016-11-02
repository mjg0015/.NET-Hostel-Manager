using MongoDB.Driver;
using System.Configuration;

namespace Domain.Service
{
    public class PersistenceService
    {
        private static IMongoClient _client;

        private static IMongoDatabase _database;

        public static IMongoClient GetClient()
        {
            if(_client == null)
            {
                _client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString);
            }

            return _client;
        }

        public static IMongoDatabase GetDatabase()
        {
            if(_client == null)
            {
                GetClient();
            }

            return _client.GetDatabase(ConfigurationManager.AppSettings.Get("MongoDbName"));
        }
    }
}
