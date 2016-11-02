using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class BedType
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}

