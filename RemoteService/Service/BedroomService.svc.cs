using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel;
using Service;
using DomainModel.DataContracts;

namespace RemoteService.Service
{
    public class BedroomService : AbstractService, IBedroomService
    {
        public async Task<bool> CreateOrUpdateAsync(BedroomDto bedroomDto)
        {
            Bedroom bedroom = _mapper.Map<Bedroom>(bedroomDto);
            return await bedroom.CreateOrUpdateAsync();
        }

        public async Task<IList<BedroomDto>> GetAllAsync()
        {
            Bedroom bedroom = new Bedroom(_bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<Bedroom> allBedrooms = await bedroom.GetAllAsync();
            return _mapper.Map<IList<BedroomDto>>(allBedrooms);
        }

        public async Task<IList<BedroomDto>> GetAvailableAsync()
        {
            Bedroom bedroom = new Bedroom(_bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<Bedroom> availableBedrooms = await bedroom.GetAvailableAsync();
            return _mapper.Map<IList<BedroomDto>>(availableBedrooms);
        }

        public async Task<bool> RemoveAsync(BedroomDto bedroomDto)
        {
            Bedroom bedroom = _mapper.Map<Bedroom>(bedroomDto);
            return await bedroom.RemoveAsync();
        }
    }
}
