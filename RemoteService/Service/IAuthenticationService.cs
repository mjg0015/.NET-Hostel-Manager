using DomainModel.DTO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        Task<UserDTO> DoLoginAsync(string username, string password);
    }
}
