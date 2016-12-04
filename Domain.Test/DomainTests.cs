using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Configuration;

namespace Domain.Test
{
    [TestClass]
    public class DomainTests
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        [TestInitialize]
        public void TestInitialize()
        {
            _client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString);
            _client.DropDatabase(ConfigurationManager.AppSettings.Get("MongoDbName"));
            _database = _client.GetDatabase(ConfigurationManager.AppSettings.Get("MongoDbName"));

            string bathroomtypes = System.IO.File.ReadAllText(@"mongodb/bathroomtypes.json");
            string bedtypes = System.IO.File.ReadAllText(@"mongodb/bedtypes.json");
            string bedrooms = System.IO.File.ReadAllText(@"mongodb/bedrooms.json");
            string guests = System.IO.File.ReadAllText(@"mongodb/guests.json");
            string checkins = System.IO.File.ReadAllText(@"mongodb/checkins.json");
            string users = System.IO.File.ReadAllText(@"mongodb/users.json");

            var bathroomtypesArray = BsonSerializer.Deserialize<BsonArray>(bathroomtypes);
            var bedtypesArray = BsonSerializer.Deserialize<BsonArray>(bedtypes);
            var bedroomsArray = BsonSerializer.Deserialize<BsonArray>(bedrooms);
            var guestsArray = BsonSerializer.Deserialize<BsonArray>(guests);
            var checkinsArray = BsonSerializer.Deserialize<BsonArray>(checkins);
            var usersArray = BsonSerializer.Deserialize<BsonArray>(users);

            PersistData(bathroomtypesArray, "bathroomTypes");
            PersistData(bedtypesArray, "bedTypes");
            PersistData(bedroomsArray, "bedrooms");
            PersistData(guestsArray, "guests");
            PersistData(checkinsArray, "checkIns");
            PersistData(usersArray, "users");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _client.DropDatabase(ConfigurationManager.AppSettings.Get("MongoDbName"));
        }

        private void PersistData(BsonArray bsonArray, string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            foreach (BsonValue value in bsonArray.ToList())
            {
                collection.InsertOne(value.AsBsonDocument);
            }
        }
    }
}
