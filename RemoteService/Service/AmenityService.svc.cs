using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel;
using Service;
using DomainModel.DataContracts;

namespace RemoteService.Service
{
    public class AmenityService : AbstractService, IAmenityService
    {
        public async Task<bool> CreateBathroomTypeAsync(BathroomTypeDto bathroomTypeDto)
        {
            BathroomType bathroomType = _mapper.Map<BathroomType>(bathroomTypeDto);
            return await bathroomType.CreateAsync();
        }

        public async Task<bool> CreateBedTypeAsync(BedTypeDto bedTypeDto)
        {
            BedType bedType = _mapper.Map<BedType>(bedTypeDto);
            return await bedType.CreateAsync();
        }

        public async Task<IList<BathroomTypeDto>> GetAllBathroomTypesAsync()
        {
            BathroomType bathroomType = new BathroomType(_bathroomTypeRepository);
            IList<BathroomType> allBathroomTypes = await bathroomType.GetAllAsync();
            return _mapper.Map<IList<BathroomTypeDto>>(allBathroomTypes);
        }

        public async Task<IList<BedTypeDto>> GetAllBedTypesAsync()
        {
            BedType bedType = new BedType(_bedTypeRepository);
            IList<BedType> allBedTypes = await bedType.GetAllAsync();
            return _mapper.Map<IList<BedTypeDto>>(allBedTypes);
        }
    }
}
