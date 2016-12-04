using DomainModel.DTO;
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
        Task<IList<CheckInDTO>> GetPendingCheckOutAsync();

        [OperationContract]
        Task<IList<CheckInDTO>> GetBetweenDatesAsync(DateTime startDate, DateTime endDate);

        [OperationContract]
        Task<bool> CreateAsync(CheckInDTO checkInDTO);

        [OperationContract]
        Task<bool> DoCheckOutAsync(CheckInDTO checkInDTO);
    }
}
