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

        [BsonElement("guests")]
        public List<Guest> Guests { get; set; }

        [BsonElement("bedroom")]
        public Bedroom Bedroom { get; set; }
    }
}
