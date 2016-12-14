using DomainModel.DataContracts;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        Task<UserDto> DoLoginAsync(string username, string password);
    }
}
