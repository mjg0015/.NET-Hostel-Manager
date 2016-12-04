using DomainModel;
using DomainModel.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
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
            IList<CheckInDTO> checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 1);
        }

        [TestMethod]
        public async Task CreateCheckIn()
        {
            GuestDTO guest1 = new GuestDTO()
            {
                DocumentId = "0000000004",
                Name = "Guest",
                Surname = "Four",
                BirthDate = new DateTime(1990,01,01),
                Sex = Sex.MALE
            };

            GuestDTO guest2 = new GuestDTO()
            {
                DocumentId = "0000000005",
                Name = "Guest",
                Surname = "Five",
                BirthDate = new DateTime(1980, 10, 05),
                Sex = Sex.FEMALE
            };

            List<GuestDTO> guestList = new List<GuestDTO>();
            guestList.Add(guest1);
            guestList.Add(guest2);

            IBedroomService bedroomServ = new BedroomService();
            List<BedroomDTO> bedroomList = new List<BedroomDTO>(await bedroomServ.GetAvailableAsync());
            BedroomDTO bedroom = bedroomList.Find(x => x.Number == 2);

            CheckInDTO checkIn = new CheckInDTO()
            {
                ArrivingDate = DateTime.Now,
                DepartureDate = DateTime.Now.AddDays(1),
                Guests = guestList,
                Bedroom = bedroom
            };

            bool result = await _checkInServ.CreateAsync(checkIn);
            Assert.IsTrue(result);

            IList<CheckInDTO> checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 2);

            bedroomList = new List<BedroomDTO>(await bedroomServ.GetAvailableAsync());
            bedroom = bedroomList.Find(x => x.Number == 2);
            Assert.IsNull(bedroom);
        }

        [TestMethod]
        public async Task DoCheckOut()
        {
            IList<CheckInDTO> checkIns = await _checkInServ.GetPendingCheckOutAsync();

            bool result;
            foreach(CheckInDTO checkIn in checkIns)
            {
                result = await _checkInServ.DoCheckOutAsync(checkIn);
                Assert.IsTrue(result);
            }

            checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 0);
        }
    }
}
