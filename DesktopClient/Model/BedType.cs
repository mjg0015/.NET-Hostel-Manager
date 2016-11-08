using MongoDB.Bson.Serialization.Attributes;

namespace DesktopClient.Model
{
    public class BedType
    {
        [BsonId]
        public string Name { get; set; }
    }
}

