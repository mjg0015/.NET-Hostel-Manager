using System.Collections.Generic;
using DesktopClient.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public interface IBedroomRepository : IRepository<Bedroom>
    {
        Task<List<Bedroom>> FindAvailableAsync();

        Task<bool> RemoveAsync(Bedroom bedroom);
    }

    public class BedroomRepository : Repository<Bedroom>, IBedroomRepository
    {

        public BedroomRepository() : base("bedrooms")
        {
        }

        public async Task<List<Bedroom>> FindAvailableAsync()
        {
            List<Bedroom> bedrooms = await _collection.Find(x => x.Available == true).ToListAsync();
            return bedrooms;
        }

        public async Task<bool> RemoveAsync(Bedroom bedroom)
        {
            var result = await _collection.DeleteOneAsync(x => x.Number == bedroom.Number);
            return result.DeletedCount > 0;
        }
    }
}
