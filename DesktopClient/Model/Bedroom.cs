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

        [BsonElement("bathroomType")]
        public BathroomType BathroomType { get; set; }

        [BsonElement("bedType")]
        public BedType BedType { get; set; }

        override
        public string ToString()
        {
            return "Bedroom № : "+ Number+" ;   Price : "+Price + " ;   Size : " + Size;
        }
    }
}
