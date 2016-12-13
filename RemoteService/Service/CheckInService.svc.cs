using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel.DTO;
using DomainModel;
using Service;

namespace RemoteService.Service
{
    public class CheckInService : AbstractService, ICheckInService
    {
        public async Task<bool> CreateAsync(CheckInDTO checkInDTO)
        {
            CheckIn checkIn = _mapper.Map<CheckIn>(checkInDTO);
            return await checkIn.CreateAsync();
        }

        public async Task<bool> DoCheckOutAsync(CheckInDTO checkInDTO)
        {
            CheckIn checkIn = _mapper.Map<CheckIn>(checkInDTO);
            return await checkIn.DoCheckOutAsync();
        }

        public async Task<IList<CheckInDTO>> GetBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            CheckIn checkIn = new CheckIn(
                _checkInRepository, _guestRepository, _bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<CheckInDTO> checkInsDTO = _mapper.Map<IList<CheckInDTO>>(await checkIn.GetBetweenDates(startDate, endDate));
            return checkInsDTO;
        }

        public async Task<IList<CheckInDTO>> GetPendingCheckOutAsync()
        {
            CheckIn checkIn = new CheckIn(
                _checkInRepository, _guestRepository, _bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<CheckInDTO> checkInsDTO = _mapper.Map<IList<CheckInDTO>>(await checkIn.GetPendingCheckOutAsync());
            return checkInsDTO;
        }
    }
}
