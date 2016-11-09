using DesktopClient.Data;
using DesktopClient.Model;
using System;
using System.Threading.Tasks;

namespace DesktopClient.Service
{
    public interface IAuthenticationService
    {
        Task<User> DoLoginAsync(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository _userRepo;

        public AuthenticationService()
        {
            _userRepo = new UserRepository();
        }

        public async Task<User> DoLoginAsync(string username, string password)
        {
            try
            {
                User user = await _userRepo.FindByNameAsync(username);
                if (password == user.Password)
                {
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }            
        }
    }
}
