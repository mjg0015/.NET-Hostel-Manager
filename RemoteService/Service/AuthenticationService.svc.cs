using System.Threading.Tasks;
using DomainModel.DTO;
using DomainModel;
using Service;

namespace RemoteService.Service
{
    public class AuthenticationService : AbstractService, IAuthenticationService
    {
        public async Task<UserDTO> DoLoginAsync(string username, string password)
        {
            User user = new User(_userRepository) {
                Name = username,
                Password = password
            };

            bool isCorrectLogin = await user.CheckAsync();
            if (isCorrectLogin)
            {
                return _mapper.Map<UserDTO>(user);
            }else
            {
                return null;
            }
        }
    }
}
