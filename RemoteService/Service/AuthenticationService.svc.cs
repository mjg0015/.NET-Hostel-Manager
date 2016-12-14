using System.Threading.Tasks;
using DomainModel;
using Service;
using DomainModel.DataContracts;

namespace RemoteService.Service
{
    public class AuthenticationService : AbstractService, IAuthenticationService
    {
        public async Task<UserDto> DoLoginAsync(string username, string password)
        {
            User user = new User(_userRepository) {
                Name = username,
                Password = password
            };

            bool isCorrectLogin = await user.CheckAsync();
            if (isCorrectLogin)
            {
                return _mapper.Map<UserDto>(user);
            }else
            {
                return null;
            }
        }
    }
}
