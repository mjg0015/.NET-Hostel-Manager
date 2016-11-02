using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum Sex
    {
        MALE = 1,
        FEMALE = 2
    }

    public class Guest
    {
        public ObjectId Id { get; set; }

        public string DocumentID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public Sex Sex { get; set; }
    }
}
