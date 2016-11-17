using MongoDB.Bson.Serialization.Attributes;

namespace DesktopClient.Model
{
    public class BedType
    {
        public BedType(string input)
        {
            Name = input;
        }

        [BsonId]
        public string Name { get; set; }
    }
}

