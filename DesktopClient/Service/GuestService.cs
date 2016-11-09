using System;
using DesktopClient.Model;
using DesktopClient.Data;
using System.Threading.Tasks;

namespace DesktopClient.Service
{
    public interface IGuestService
    {
        Task<Guest> FindGuestByIdAsync(string id);

        Task<bool> CreateOrUpdateAsync(Guest guest);
    }

    public class GuestService : IGuestService
    {
        private IGuestRepository _guestRepo;

        public GuestService()
        {
            _guestRepo = new GuestRepository();
        }

        public async Task<bool> CreateOrUpdateAsync(Guest guest)
        {
            try
            {
                return await _guestRepo.InsertOrUpdateAsync(guest);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Guest> FindGuestByIdAsync(string id)
        {
            try
            {
                return await _guestRepo.FindByIdAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
