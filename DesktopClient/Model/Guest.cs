using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesktopClient.Model
{
    public enum Sex
    {
        MALE,
        FEMALE
    }

    public class Guest
    {
        [BsonId]
        public string DocumentId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [BsonElement("sex")]
        [BsonRepresentation(BsonType.String)]
        public Sex Sex { get; set; }
    }
}
