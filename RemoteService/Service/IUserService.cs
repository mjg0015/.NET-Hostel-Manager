using DomainModel.DataContracts;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Task<UserDto> DoLoginAsync(UserDto userDto, string password);

        [OperationContract]
        Task<bool> RegisterAsync(UserDto userDto, string password);
    }
}
