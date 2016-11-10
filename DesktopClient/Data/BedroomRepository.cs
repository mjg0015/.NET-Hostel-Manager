using System.Collections.Generic;
using DesktopClient.Model;
using MongoDB.Driver;
using System.Threading.Tasks;
using System;

namespace DesktopClient.Data
{
    public interface IBedroomRepository : IRepository<Bedroom>
    {
        Task<Bedroom> FindByIdAsync(int id);

        Task<List<Bedroom>> FindByAvailabilityAsync(bool availability);

        Task<bool> InsertOrUpdateAsync(Bedroom bedroom);

        Task<bool> RemoveAsync(Bedroom bedroom);
    }

    public class BedroomRepository : Repository<Bedroom>, IBedroomRepository
    {
        private BathroomTypeRepository _bathroomTypeRepo;

        private BedTypeRepository _bedTypeRepo;

        public BedroomRepository() : base("bedrooms")
        {
            _bathroomTypeRepo = new BathroomTypeRepository();

            _bedTypeRepo = new BedTypeRepository();
        }

        public async Task<bool> InsertOrUpdateAsync(Bedroom bedroom)
        {
            await _bathroomTypeRepo.InsertAsync(bedroom.BathroomType);
            await _bedTypeRepo.InsertAsync(bedroom.BedType);

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

        public async new Task<List<Bedroom>> FindAllAsync()
        {
            List<Bedroom> bedrooms = await base.FindAllAsync();
            return await FillAmenitiesUtil(bedrooms);
        }

        public async Task<Bedroom> FindByIdAsync(int id)
        {
            Bedroom bedroom = null;
            var found = _collection.Find(x => x.Number == id);
            if (found.Count() > 0)
            {
                bedroom = await found.FirstAsync();
            }

            return await FillAmenitiesUtil(bedroom);
        }

        public async Task<List<Bedroom>> FindByAvailabilityAsync(bool availability)
        {
            List<Bedroom> bedrooms = await _collection.Find(x => x.Available == availability).ToListAsync();
            return await FillAmenitiesUtil(bedrooms);
        }

        public async Task<bool> RemoveAsync(Bedroom bedroom)
        {
            var result = await _collection.DeleteOneAsync(x => x.Number == bedroom.Number);
            return result.DeletedCount > 0;
        }

        private async Task<List<Bedroom>> FillAmenitiesUtil(List<Bedroom> bedrooms)
        {
            List<Bedroom> bedroomsFilled = new List<Bedroom>();

            foreach (Bedroom bedroom in bedrooms)
            {
                bedroomsFilled.Add(await FillAmenitiesUtil(bedroom));
            }

            return bedroomsFilled;
        }

        private async Task<Bedroom> FillAmenitiesUtil(Bedroom bedroom)
        {
            bedroom.BathroomType = await _bathroomTypeRepo.FindByTypeAsync(bedroom.BathroomTypeRef);
            bedroom.BedType = await _bedTypeRepo.FindByTypeAsync(bedroom.BedTypeRef);
            return bedroom;
        }
    }
}
