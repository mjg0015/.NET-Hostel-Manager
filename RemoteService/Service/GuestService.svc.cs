using System.Threading.Tasks;
using DomainModel;
using Service;
using DomainModel.DataContracts;

namespace RemoteService.Service
{
    public class GuestService : AbstractService, IGuestService
    {
        public async Task<bool> CreateOrUpdateAsync(GuestDto guestDto)
        {
            Guest guest = _mapper.Map<Guest>(guestDto);
            return await guest.CreateOrUpdateAsync();
        }

        public async Task<GuestDto> FindGuestByIdAsync(string id)
        {
            Guest guest = new Guest(_guestRepository);
            GuestDto guestDto = _mapper.Map<GuestDto>(await guest.GetByDocumentId(id));
            return guestDto;
        }
    }
}
