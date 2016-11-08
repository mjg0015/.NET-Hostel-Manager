using System;
using MongoDB.Bson.Serialization.Attributes;

namespace DesktopClient.Model
{
    public enum Sex
    {
        MALE = 1,
        FEMALE = 2
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
        public Sex Sex { get; set; }
    }
}
