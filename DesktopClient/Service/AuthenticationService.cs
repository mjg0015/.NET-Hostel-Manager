using Domain.Data;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
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
