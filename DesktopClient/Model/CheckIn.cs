using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DesktopClient.Model
{
    public class CheckIn
    {
        public ObjectId Id { get; set; }

        [BsonElement("arrivingDate")]
        public DateTime ArrivingDate { get; set; }

        [BsonElement("departureDate")]
        public DateTime DepartureDate { get; set; }

        [BsonIgnore]
        public List<Guest> Guests { get; set; }

        [BsonElement("guests")]
        public List<string> GuestsRef { get; set; }

        [BsonIgnore]
        public Bedroom Bedroom { get; set; }

        [BsonElement("bedroom")]
        public int BedroomRef { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        public override string ToString()
        {
            if (Bedroom!=null)
            {
                return Bedroom.ToString();
            }
            return "-";
        }
    }
}
