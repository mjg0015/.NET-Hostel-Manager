using DesktopClient.Model;
using DesktopClient.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    [TestClass]
    public class AuthenticationTests : DomainTests
    {
        private AuthenticationService _authenticationServ;

        public AuthenticationTests()
        {
            _authenticationServ = new AuthenticationService();
        }

        [TestMethod]
        public async Task DoLoginWithValidCredentials()
        {
            string username = "manager";
            string password = "password";
            User user = await _authenticationServ.DoLoginAsync(username, password);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Name, username);
        }

        [TestMethod]
        public async Task DoLoginWithInvalidCredentials()
        {
            string username = "fakeuser";
            string password = "fakepass";
            User user = await _authenticationServ.DoLoginAsync(username, password);

            Assert.IsNull(user);
        }
    }
}
