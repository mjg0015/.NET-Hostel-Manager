using DesktopClient.Model;
using MongoDB.Driver;

namespace DesktopClient.Data
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
