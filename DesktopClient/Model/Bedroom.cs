using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Bedroom
    {
        public ObjectId Id { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        public int Size { get; set; }

        public bool Available { get; set; }

        public BathroomType BathroomType { get; set; }

        public BedType BedType { get; set; }
    }
}
