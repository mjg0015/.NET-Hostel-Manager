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
    public class CheckInTests : DomainTests
    {
        private ICheckInService _checkInServ;

        private IBedroomService _bedroomServ;

        public CheckInTests()
        {
            _checkInServ = new CheckInService();
        }

        [TestMethod]
        public async Task GetCheckInsWithPendingCheckOut()
        {
            List<CheckIn> checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 1);
        }

        [TestMethod]
        public async Task CreateCheckIn()
        {
            Guest guest1 = new Guest()
            {
                DocumentId = "0000000004",
                Name = "Guest",
                Surname = "Four",
                BirthDate = new DateTime(1990,01,01),
                Sex = Sex.MALE
            };

            Guest guest2 = new Guest()
            {
                DocumentId = "0000000005",
                Name = "Guest",
                Surname = "Five",
                BirthDate = new DateTime(1980, 10, 05),
                Sex = Sex.FEMALE
            };

            List<Guest> guestList = new List<Guest>();
            guestList.Add(guest1);
            guestList.Add(guest2);

            IBedroomService bedroomServ = new BedroomService();
            List<Bedroom> bedroomList = await bedroomServ.GetAvailableAsync();
            Bedroom bedroom = bedroomList.Find(x => x.Number == 2);

            CheckIn checkIn = new CheckIn()
            {
                ArrivingDate = DateTime.Now,
                DepartureDate = DateTime.Now.AddDays(1),
                Guests = guestList,
                Bedroom = bedroom
            };

            bool result = await _checkInServ.CreateAsync(checkIn);
            Assert.IsTrue(result);

            List<CheckIn> checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 2);

            bedroomList = await bedroomServ.GetAvailableAsync();
            bedroom = bedroomList.Find(x => x.Number == 2);
            Assert.IsNull(bedroom);
        }

        [TestMethod]
        public async Task DoCheckOut()
        {
            List<CheckIn> checkIns = await _checkInServ.GetPendingCheckOutAsync();

            bool result;
            foreach(CheckIn checkIn in checkIns)
            {
                result = await _checkInServ.DoCheckOutAsync(checkIn);
                Assert.IsTrue(result);
            }

            checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 0);
        }
    }
}
