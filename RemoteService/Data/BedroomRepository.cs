using System.Collections.Generic;
using DomainModel;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Data
{
    public interface IBedroomRepository : IRepository<Bedroom>
    {
        Task<Bedroom> FindByIdAsync(int id);

        Task<IList<Bedroom>> FindByAvailabilityAsync(bool availability);

        Task<bool> InsertOrUpdateAsync(Bedroom bedroom);

        Task<bool> RemoveAsync(Bedroom bedroom);
    }

    public class BedroomRepository : Repository<Bedroom>, IBedroomRepository
    {
        public BedroomRepository(IMongoDatabase db) : base(db, Bedroom.COLLECTION_NAME)
        {
        }

        public async Task<bool> InsertOrUpdateAsync(Bedroom bedroom)
        {
            bedroom.BathroomTypeRef = bedroom.BathroomType.Name;
            bedroom.BedTypeRef = bedroom.BedType.Name;

            bool status = await base.InsertAsync(bedroom);
            if (!status)
            {
                var filter = Builders<Bedroom>.Filter.Eq("Number", bedroom.Number);
                var result = await _collection.ReplaceOneAsync(filter, bedroom);
                status = result.ModifiedCount > 0;
            }

            return status;
        }

        public async new Task<IList<Bedroom>> FindAllAsync()
        {
            IList<Bedroom> bedrooms = await base.FindAllAsync();
            return bedrooms;
        }

        public async Task<Bedroom> FindByIdAsync(int id)
        {
            Bedroom bedroom = null;
            var found = _collection.Find(x => x.Number == id);
            if (found.Count() > 0)
            {
                bedroom = await found.FirstAsync();
            }

            return bedroom;
        }

        public async Task<IList<Bedroom>> FindByAvailabilityAsync(bool availability)
        {
            List<Bedroom> bedrooms = await _collection.Find(x => x.Available == availability).ToListAsync();
            return bedrooms;
        }

        public async Task<bool> RemoveAsync(Bedroom bedroom)
        {
            var result = await _collection.DeleteOneAsync(x => x.Number == bedroom.Number);
            return result.DeletedCount > 0;
        }
    }
}
