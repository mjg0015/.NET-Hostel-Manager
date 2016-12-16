using DomainModel.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteService.Service;
using Service;
using System.Threading.Tasks;

namespace Domain.Test
{
    [TestClass]
    public class AuthenticationTests : DomainTests
    {
        private IAuthenticationService _authenticationServ;

        public AuthenticationTests()
        {
            _authenticationServ = new AuthenticationService();
        }

        [TestMethod]
        public async Task DoLoginWithValidCredentials()
        {
            string username = "manager";
            string password = "password";
            UserDto user = await _authenticationServ.DoLoginAsync(username, password);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Name, username);
        }

        [TestMethod]
        public async Task DoLoginWithInvalidCredentials()
        {
            string username = "fakeuser";
            string password = "fakepass";
            UserDto user = await _authenticationServ.DoLoginAsync(username, password);

            Assert.IsNull(user);
        }
    }
}
