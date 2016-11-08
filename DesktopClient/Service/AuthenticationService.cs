using DesktopClient.Data;
using DesktopClient.Model;

namespace DesktopClient.Service
{
    public interface IAuthenticationService
    {
        User DoLogin(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        public User DoLogin(string username, string password)
        {
            UserRepository userRepo = new UserRepository();
            User user = userRepo.FindByName(username);
            if(password == user.Password)
            {
                return user;
            }
            return null;
        }
    }
}
