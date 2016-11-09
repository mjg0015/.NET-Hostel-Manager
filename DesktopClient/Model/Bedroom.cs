using MongoDB.Bson.Serialization.Attributes;

namespace DesktopClient.Model
{
    public class Bedroom
    {
        [BsonId]
        public int Number { get; set; }

        [BsonElement("price")]
        public double Price { get ; set; }

        [BsonElement("size")]
        public int Size { get; set; }

        [BsonElement("available")]
        public bool Available { get; set; }

        [BsonIgnore]
        public BathroomType BathroomType { get; set; }

        [BsonElement("bathroomType")]
        public string BathroomTypeRef { get; set; }

        [BsonIgnore]
        public BedType BedType { get; set; }

        [BsonElement("bedType")]
        public string BedTypeRef { get; set; }

        override
        public string ToString()
        {
            return "Bedroom № : "+ Number+" ;   Price : "+Price + " ;   Size : " + Size;
        }
    }
}
