using MongoDB.Bson.Serialization.Attributes;

namespace DesktopClient.Model
{
    public class BathroomType
    {
        [BsonId]
        public string Name { get; set; }
    }
}
