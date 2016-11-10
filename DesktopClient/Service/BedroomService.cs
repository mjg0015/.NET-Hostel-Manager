using System;
using System.Collections.Generic;
using DesktopClient.Data;
using DesktopClient.Model;
using System.Threading.Tasks;

namespace DesktopClient.Service
{
    public interface IBedroomService
    {
        Task<List<Bedroom>> GetAllAsync();

        Task<List<Bedroom>> GetAvailableAsync();

        Task<List<Bedroom>> GetFilteredAsync(int minSize, double maxPrice, BathroomType bathroomType, BedType bedType, bool available);

        Task<bool> CreateOrUpdateAsync(Bedroom bedroom);

        Task<bool> RemoveAsync(Bedroom bedroom);
    }

    public class BedroomService : IBedroomService
    {
        private IBedroomRepository _bedroomRepo;

        public BedroomService()
        {
            _bedroomRepo = new BedroomRepository();
        }

        public async Task<bool> CreateOrUpdateAsync(Bedroom bedroom)
        {
            return await _bedroomRepo.InsertOrUpdateAsync(bedroom);
        }

        public async Task<List<Bedroom>> GetAllAsync()
        {
            return await _bedroomRepo.FindAllAsync();
        }

        public async Task<List<Bedroom>> GetAvailableAsync()
        {
            return await _bedroomRepo.FindByAvailabilityAsync(true);
        }

        public async Task<List<Bedroom>> GetFilteredAsync(int minSize, double maxPrice, BathroomType bathroomType, BedType bedType, bool available)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(Bedroom bedroom)
        {
            return await _bedroomRepo.RemoveAsync(bedroom);
        }
    }
}
