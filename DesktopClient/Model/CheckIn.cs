using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
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
