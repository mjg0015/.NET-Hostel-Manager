using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User
    {
        [BsonId]
        public string Name { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}
