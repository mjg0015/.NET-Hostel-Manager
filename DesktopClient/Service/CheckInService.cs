using System;
using DesktopClient.Model;
using DesktopClient.Data;
using System.Threading.Tasks;

namespace DesktopClient.Service
{
    public interface ICheckInService
    {
        Task<bool> CreateAsync(CheckIn checkIn);

        Task<bool> DoCheckOutAsync(CheckIn checkIn);
    }

    public class CheckInService : ICheckInService
    {
        private ICheckInRepository _checkInRepo;

        public CheckInService()
        {
            _checkInRepo = new CheckInRepository();
        }

        public async Task<bool> CreateAsync(CheckIn checkIn)
        {
            try
            {
                bool created = await _checkInRepo.InsertOrUpdateAsync(checkIn);
                return created;
            }
            catch (Exception)
            {
                return false;
            }   
        }

        public async Task<bool> DoCheckOutAsync(CheckIn checkIn)
        {
            checkIn.Bedroom.Available = true;
            try
            {
                bool updated = await _checkInRepo.InsertOrUpdateAsync(checkIn);
                return updated;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
