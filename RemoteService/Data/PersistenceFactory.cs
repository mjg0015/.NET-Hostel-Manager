using MongoDB.Driver;
using System.Configuration;

namespace Data
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
