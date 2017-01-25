using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteService.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void PasswordHashing()
        {
            string password1 = "password";
            string password2 = "password";

            string encoded = PasswordUtils.Encode(password1);
            Assert.IsTrue(PasswordUtils.IsCorrect(encoded, password2));

            Assert.IsFalse(PasswordUtils.IsCorrect(encoded, "badpassword"));
        }
    }
}
