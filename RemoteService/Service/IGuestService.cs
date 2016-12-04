using DomainModel.DTO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IGuestService
    {
        [OperationContract]
        Task<bool> CreateOrUpdateAsync(GuestDTO guestDTO);

        [OperationContract]
        Task<GuestDTO> FindGuestByIdAsync(string id);
    }
}
