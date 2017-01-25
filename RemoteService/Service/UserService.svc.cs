using System.Threading.Tasks;
using DomainModel;
using Service;
using DomainModel.DataContracts;
using System;

namespace RemoteService.Service
{
    public class UserService : AbstractService, IUserService
    {
        public async Task<UserDto> DoLoginAsync(UserDto userDto, string password)
        {
            User user = _mapper.Map<User>(userDto);
            user.Password = password;
            
            bool isCorrectLogin = await user.CheckAsync();
            if (isCorrectLogin)
            {
                return _mapper.Map<UserDto>(user);
            }else
            {
                return null;
            }
        }

        public async Task<bool> RegisterAsync(UserDto userDto, string password)
        {
            User user = _mapper.Map<User>(userDto);
            user.Password = password;
            return await user.Register();
        }
    }
}
