using DomainModel.DataContracts;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IGuestService
    {
        [OperationContract]
        Task<bool> CreateOrUpdateAsync(GuestDto guestDto);

        [OperationContract]
        Task<GuestDto> FindGuestByIdAsync(string id);
    }
}
