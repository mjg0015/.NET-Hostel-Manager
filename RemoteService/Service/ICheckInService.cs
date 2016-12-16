using DomainModel.DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface ICheckInService
    {
        [OperationContract]
        Task<IList<CheckInDto>> GetPendingCheckOutAsync();

        [OperationContract]
        Task<IList<CheckInDto>> GetBetweenDatesAsync(DateTime startDate, DateTime endDate);

        [OperationContract]
        Task<IList<CheckInDto>> GetBetweenDatesAsync();

        [OperationContract]
        Task<bool> CreateAsync(CheckInDto checkInDto);

        [OperationContract]
        Task<bool> DoCheckOutAsync(CheckInDto checkInDto);
    }
}
