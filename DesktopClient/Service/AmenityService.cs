using System.Collections.Generic;
using DesktopClient.Data;
using DesktopClient.Model;
using System;
using System.Threading.Tasks;

namespace DesktopClient.Service
{
    public interface IAmenityService
    {
        Task<List<BedType>> GetAllBedTypesAsync();

        Task<List<BathroomType>> GetAllBathroomTypesAsync();

        Task<bool> CreateBedTypeAsync(BedType bedType);

        Task<bool> CreateBathroomTypeAsync(BathroomType bathroomType);
    }

    public class AmenityService : IAmenityService
    {
        private IRepository<BedType> _bedTypeRepo;

        private IRepository<BathroomType> _bathroomTypeRepo;

        public AmenityService()
        {
            _bedTypeRepo = new BedTypeRepository();
            _bathroomTypeRepo = new BathroomTypeRepository();
        }

        public async Task<bool> CreateBathroomTypeAsync(BathroomType bathroomType)
        {
            try
            {
                return await _bathroomTypeRepo.InsertAsync(bathroomType);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateBedTypeAsync(BedType bedType)
        {
            try
            {
                return await _bedTypeRepo.InsertAsync(bedType);
            }
            catch (Exception)
            {
                return false;
            }      
        }

        public async Task<List<BathroomType>> GetAllBathroomTypesAsync()
        {
            try
            {
                return await _bathroomTypeRepo.FindAllAsync();
            }
            catch (Exception)
            {
                return null;
            }        
        }

        public async Task<List<BedType>> GetAllBedTypesAsync()
        {
            try
            {
                return await _bedTypeRepo.FindAllAsync();
            }
            catch (Exception)
            {
                return null;
            } 
        }
    }
}
