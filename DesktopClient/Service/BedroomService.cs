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
            try
            {
                return await _bedroomRepo.InsertOrUpdateAsync(bedroom);
            }
            catch (Exception)
            {
                return false;
            } 
        }

        public async Task<List<Bedroom>> GetAllAsync()
        {
            try
            {
                return await _bedroomRepo.FindAllAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Bedroom>> GetAvailableAsync()
        {
            try
            {
                return await _bedroomRepo.FindByAvailabilityAsync(true);
            }
            catch (Exception)
            {
                return null;
            }  
        }

        public async Task<List<Bedroom>> GetFilteredAsync(int minSize, double maxPrice, BathroomType bathroomType, BedType bedType, bool available)
        {
            try
            {
                return await _bedroomRepo.FindFiltered(minSize, maxPrice, bathroomType, bedType, available);
            }
            catch (Exception)
            {
                return null;
            }   
        }

        public async Task<bool> RemoveAsync(Bedroom bedroom)
        {
            try
            {
                return await _bedroomRepo.RemoveAsync(bedroom);
            }
            catch (Exception)
            {
                return false;
            }            
        }
    }
}
