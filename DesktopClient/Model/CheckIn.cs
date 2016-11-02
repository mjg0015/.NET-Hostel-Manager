using MongoDB.Bson;
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

        public DateTime ArrivingDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public List<Guest> Guests { get; set; }

        public Bedroom Bedroom { get; set; }
    }
}
