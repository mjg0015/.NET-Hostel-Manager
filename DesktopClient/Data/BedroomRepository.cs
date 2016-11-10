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

        Task<List<Bedroom>> FindAvailableAsync();

        Task<List<Bedroom>> FindUnavailableAsync();

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

        public async new Task<bool> InsertOrUpdateAsync(Bedroom bedroom)
        {
            bool bathroomTypeInserted = await _bathroomTypeRepo.InsertOrUpdateAsync(bedroom.BathroomType);
            /*if (!bathroomTypeInserted)
            {
                return false;
            }*/

            bool bedTypeInserted = await _bedTypeRepo.InsertOrUpdateAsync(bedroom.BedType);
            /*if (!bedTypeInserted)
            {
                return false;
            }*/

            bedroom.BathroomTypeRef = bedroom.BathroomType.Name;
            bedroom.BedTypeRef = bedroom.BedType.Name;

            return await base.InsertOrUpdateAsync(bedroom);
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

            return bedroom;
        }

        public async Task<List<Bedroom>> FindAvailableAsync()
        {
            List<Bedroom> bedrooms = await _collection.Find(x => x.Available == true).ToListAsync();
            return await FillAmenitiesUtil(bedrooms);
        }

        public async Task<List<Bedroom>> FindUnavailableAsync()
        {
            List<Bedroom> bedrooms = await _collection.Find(x => x.Available == false).ToListAsync();
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
                bedroom.BathroomType = await _bathroomTypeRepo.FindByTypeAsync(bedroom.BathroomTypeRef);
                bedroom.BedType = await _bedTypeRepo.FindByTypeAsync(bedroom.BedTypeRef);
                bedroomsFilled.Add(bedroom);
            }

            return bedroomsFilled;
        }
    }
}
