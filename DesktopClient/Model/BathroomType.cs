using MongoDB.Bson.Serialization.Attributes;

namespace DesktopClient.Model
{
    public class BathroomType
    {
        public BathroomType(string input)
        {
            Name = input;
        }
        [BsonId]
        public string Name { get; set; }
    }
}
