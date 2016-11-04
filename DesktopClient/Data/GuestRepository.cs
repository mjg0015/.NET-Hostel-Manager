using Domain.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Guest FindById(string id);
    }

    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository() : base("guests")
        {
        }

        public Guest FindById(string id)
        {
            Guest guest = null;
            var found = _collection.Find(x => x.DocumentId == id);
            if(found.Count() > 0)
            {
                guest = found.First();
            }

            return guest;
        }
    }
}
