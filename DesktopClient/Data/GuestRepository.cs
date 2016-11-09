using DesktopClient.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Task<Guest> FindByIdAsync(string id);
    }

    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository() : base("guests")
        {
        }

        public async Task<Guest> FindByIdAsync(string id)
        {
            Guest guest = null;
            var found = _collection.Find(x => x.DocumentId == id);
            if(found.Count() > 0)
            {
                guest = await found.FirstAsync();
            }

            return guest;
        }
    }
}
