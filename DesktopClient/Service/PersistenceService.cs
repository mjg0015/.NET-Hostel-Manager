using System.Configuration;
using MongoDB.Driver;

namespace DesktopClient.Service
{
    public static class PersistenceService
    {
        private static IMongoClient _client;

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
