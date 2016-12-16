using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel;
using Service;
using DomainModel.DataContracts;

namespace RemoteService.Service
{
    public class CheckInService : AbstractService, ICheckInService
    {
        public async Task<bool> CreateAsync(CheckInDto checkInDto)
        {
            CheckIn checkIn = _mapper.Map<CheckIn>(checkInDto);
            return await checkIn.CreateAsync();
        }

        public async Task<bool> DoCheckOutAsync(CheckInDto checkInDto)
        {
            CheckIn checkIn = _mapper.Map<CheckIn>(checkInDto);
            return await checkIn.DoCheckOutAsync();
        }

        public async Task<IList<CheckInDto>> GetBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            CheckIn checkIn = new CheckIn(
                _checkInRepository, _guestRepository, _bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<CheckInDto> checkInsDto = _mapper.Map<IList<CheckInDto>>(await checkIn.GetBetweenDates(startDate, endDate));
            return checkInsDto;
        }

        public async Task<IList<CheckInDto>> GetAllAsync()
        {
            CheckIn checkIn = new CheckIn(
                _checkInRepository, _guestRepository, _bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<CheckInDto> checkInsDto = _mapper.Map<IList<CheckInDto>>(await checkIn.GetAll());
            return checkInsDto;
        }

        public async Task<IList<CheckInDto>> GetPendingCheckOutAsync()
        {
            CheckIn checkIn = new CheckIn(
                _checkInRepository, _guestRepository, _bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            IList<CheckInDto> checkInsDto = _mapper.Map<IList<CheckInDto>>(await checkIn.GetPendingCheckOutAsync());
            return checkInsDto;
        }
    }
}
