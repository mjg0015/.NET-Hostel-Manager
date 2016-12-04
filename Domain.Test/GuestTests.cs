using DomainModel;
using DomainModel.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Threading.Tasks;

namespace Domain.Test
{
    [TestClass]
    public class GuestTests : DomainTests
    {
        private IGuestService _guestServ;

        public GuestTests()
        {
            _guestServ = new GuestService();
        }

        [TestMethod]
        public async Task FindGuestById()
        {
            GuestDTO guest = await _guestServ.FindGuestByIdAsync("0000000001");
            Assert.AreEqual(guest.Name, "Karl");

            guest = await _guestServ.FindGuestByIdAsync("0000000009");
            Assert.IsNull(guest);
        }

        [TestMethod]
        public async Task CreateGuest()
        {
            GuestDTO guest = new GuestDTO()
            {
                DocumentId = "0000000004",
                Name = "Guest",
                Surname = "Four",
                BirthDate = new DateTime(1990, 01, 01),
                Sex = Sex.MALE
            };

            bool result = await _guestServ.CreateOrUpdateAsync(guest);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateGuest()
        {
            GuestDTO guest = await _guestServ.FindGuestByIdAsync("0000000001");
            guest.Name = "Guest";

            bool result = await _guestServ.CreateOrUpdateAsync(guest);
            Assert.IsTrue(result);

            guest = await _guestServ.FindGuestByIdAsync("0000000001");
            Assert.AreEqual(guest.Name, "Guest");
        }
    }
}
