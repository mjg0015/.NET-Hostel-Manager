using DesktopClient.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Task<Guest> FindByIdAsync(string id);

        Task<bool> InsertOrUpdateAsync(Guest guest);
    }

    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository() : base("guests")
        {
        }

        public async Task<bool> InsertOrUpdateAsync(Guest guest)
        {
            bool status = await base.InsertAsync(guest);
            if (!status)
            {
                var filter = Builders<Guest>.Filter.Eq("DocumentId", guest.DocumentId);
                var result = await _collection.ReplaceOneAsync(filter, guest);
                status = result.ModifiedCount > 0;
            }

            return status;
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
