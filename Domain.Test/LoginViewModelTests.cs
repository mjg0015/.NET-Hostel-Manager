using System;
using System.Collections.Generic;
using DesktopClient.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test
{
    [TestClass]
    public class LoginViewModelTests
    {
        private LoginViewModel loginViewModel;

        public LoginViewModelTests()
        {
            loginViewModel=new LoginViewModel();
        }

        [TestMethod]
        public void LoginAction()
        {
            loginViewModel.User.Name = "manager";
            loginViewModel.User.Password = "password";
            loginViewModel.LoginAction();
            Assert.AreEqual(loginViewModel.ErrorMessage,null);
            loginViewModel.User.Name = "1234";
            loginViewModel.User.Password = "12345";
            loginViewModel.LoginAction();
            Assert.AreEqual(loginViewModel.ErrorMessage, "Invalid User name or Password! Please, reenter your credentials.");
        }
    }
}
