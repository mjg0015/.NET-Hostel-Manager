using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel.DTO;
using DomainModel;

namespace Service
{
    public class BedroomService : AbstractService, IBedroomService
    {
        public async Task<bool> CreateOrUpdateAsync(BedroomDTO bedroomDTO)
        {
            Bedroom bedroom = _mapper.Map<Bedroom>(bedroomDTO);
            return await bedroom.CreateOrUpdateAsync();
        }

        public async Task<IList<BedroomDTO>> GetAllAsync()
        {
            Bedroom bedroom = new Bedroom(_bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<Bedroom> allBedrooms = await bedroom.GetAllAsync();
            return _mapper.Map<IList<BedroomDTO>>(allBedrooms);
        }

        public async Task<IList<BedroomDTO>> GetAvailableAsync()
        {
            Bedroom bedroom = new Bedroom(_bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<Bedroom> availableBedrooms = await bedroom.GetAvailableAsync();
            return _mapper.Map<IList<BedroomDTO>>(availableBedrooms);
        }

        public async Task<bool> RemoveAsync(BedroomDTO bedroomDTO)
        {
            Bedroom bedroom = _mapper.Map<Bedroom>(bedroomDTO);
            return await bedroom.RemoveAsync();
        }
    }
}
