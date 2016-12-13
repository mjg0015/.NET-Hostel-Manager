using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.DTO;
using Service;

namespace RemoteService.Service
{
    public class AmenityService : AbstractService, IAmenityService
    {
        public async Task<bool> CreateBathroomTypeAsync(BathroomTypeDTO bathroomTypeDTO)
        {
            BathroomType bathroomType = _mapper.Map<BathroomType>(bathroomTypeDTO);
            return await bathroomType.CreateAsync();
        }

        public async Task<bool> CreateBedTypeAsync(BedTypeDTO bedTypeDTO)
        {
            BedType bedType = _mapper.Map<BedType>(bedTypeDTO);
            return await bedType.CreateAsync();
        }

        public async Task<IList<BathroomTypeDTO>> GetAllBathroomTypesAsync()
        {
            BathroomType bathroomType = new BathroomType(_bathroomTypeRepository);
            IList<BathroomType> allBathroomTypes = await bathroomType.GetAllAsync();
            return _mapper.Map<IList<BathroomTypeDTO>>(allBathroomTypes);
        }

        public async Task<IList<BedTypeDTO>> GetAllBedTypesAsync()
        {
            BedType bedType = new BedType(_bedTypeRepository);
            IList<BedType> allBedTypes = await bedType.GetAllAsync();
            return _mapper.Map<IList<BedTypeDTO>>(allBedTypes);
        }
    }
}
