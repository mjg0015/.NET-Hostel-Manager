using MongoDB.Bson.Serialization.Attributes;

namespace DesktopClient.Model
{
    public class User
    {
        [BsonId]
        public string Name { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}
