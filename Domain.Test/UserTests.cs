using DomainModel.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteService.Service;
using Service;
using System.Threading.Tasks;

namespace Domain.Test
{
    [TestClass]
    public class UserTests : DomainTests
    {
        private IUserService _userServ;

        public UserTests()
        {
            _userServ = new UserService();
        }

        [TestMethod]
        public async Task DoLoginWithValidCredentials()
        {
            UserDto manager = new UserDto()
            {
                Name = "manager",
                Role = Role.MANAGER
            };
            string password = "password";
            UserDto user = await _userServ.DoLoginAsync(manager, password);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Name, manager.Name);
            Assert.AreEqual(user.Role, manager.Role);
        }

        [TestMethod]
        public async Task DoLoginWithInvalidCredentials()
        {
            UserDto fakeuser = new UserDto()
            {
                Name = "fakeuser",
                Role = Role.MANAGER
            };
            string password = "fakepass";
            UserDto user = await _userServ.DoLoginAsync(fakeuser, password);

            Assert.IsNull(user);
        }

        [TestMethod]
        public async Task CreateUser()
        {
            string username = "newUser";
            string password = "password";
            UserDto user = new UserDto()
            {
                Name = username,
                Role = Role.USER
            };
            

            bool created = await _userServ.RegisterAsync(user, password);

            UserDto registeredUser = await _userServ.DoLoginAsync(user, password);
            Assert.AreEqual(user.Name, registeredUser.Name);
            Assert.AreEqual(user.Role, registeredUser.Role);
        }
    }
}
