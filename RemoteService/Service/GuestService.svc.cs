using System.Threading.Tasks;
using DomainModel.DTO;
using DomainModel;
using System;

namespace Service
{
    public class GuestService : AbstractService, IGuestService
    {
        public async Task<bool> CreateOrUpdateAsync(GuestDTO guestDTO)
        {
            Guest guest = _mapper.Map<Guest>(guestDTO);
            return await guest.CreateOrUpdateAsync();
        }

        public async Task<GuestDTO> FindGuestByIdAsync(string id)
        {
            Guest guest = new Guest(_guestRepository);
            GuestDTO guestDTO = _mapper.Map<GuestDTO>(await guest.GetByDocumentId(id));
            return guestDTO;
        }
    }
}
