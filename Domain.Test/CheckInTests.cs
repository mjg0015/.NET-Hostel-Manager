using DomainModel.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteService.Service;
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

        public CheckInTests()
        {
            _checkInServ = new CheckInService();
        }

        [TestMethod]
        public async Task GetCheckInsWithPendingCheckOut()
        {
            IList<CheckInDto> checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 1);
        }

        [TestMethod]
        public async Task GetCheckInsBetweenDates()
        {
            DateTime startDate = new DateTime(2016, 08, 01);
            DateTime endDate = new DateTime(2016, 10, 01);

            IList<CheckInDto> checkIns = await _checkInServ.GetBetweenDatesAsync(startDate, endDate);
            Assert.AreEqual(checkIns.Count, 2);
        }

        [TestMethod]
        public async Task GetAllCheckIns()
        {
            IList<CheckInDto> checkIns = await _checkInServ.GetBetweenDatesAsync();
            Assert.AreEqual(checkIns.Count, 4);
        }

        [TestMethod]
        public async Task CreateCheckIn()
        {
            GuestDto guest1 = new GuestDto()
            {
                DocumentId = "0000000004",
                Name = "Guest",
                Surname = "Four",
                BirthDate = new DateTime(1990,01,01),
                Sex = Sex.MALE
            };

            GuestDto guest2 = new GuestDto()
            {
                DocumentId = "0000000005",
                Name = "Guest",
                Surname = "Five",
                BirthDate = new DateTime(1980, 10, 05),
                Sex = Sex.FEMALE
            };

            List<GuestDto> guestList = new List<GuestDto>();
            guestList.Add(guest1);
            guestList.Add(guest2);

            IBedroomService bedroomServ = new BedroomService();
            List<BedroomDto> bedroomList = new List<BedroomDto>(await bedroomServ.GetAvailableAsync());
            BedroomDto bedroom = bedroomList.Find(x => x.Number == 2);

            CheckInDto checkIn = new CheckInDto()
            {
                ArrivingDate = DateTime.Now,
                DepartureDate = DateTime.Now.AddDays(1),
                Guests = guestList,
                Bedroom = bedroom
            };

            bool result = await _checkInServ.CreateAsync(checkIn);
            Assert.IsTrue(result);

            IList<CheckInDto> checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 2);

            bedroomList = new List<BedroomDto>(await bedroomServ.GetAvailableAsync());
            bedroom = bedroomList.Find(x => x.Number == 2);
            Assert.IsNull(bedroom);
        }

        [TestMethod]
        public async Task DoCheckOut()
        {
            IList<CheckInDto> checkIns = await _checkInServ.GetPendingCheckOutAsync();

            bool result;
            foreach(CheckInDto checkIn in checkIns)
            {
                result = await _checkInServ.DoCheckOutAsync(checkIn);
                Assert.IsTrue(result);
            }

            checkIns = await _checkInServ.GetPendingCheckOutAsync();
            Assert.AreEqual(checkIns.Count, 0);
        }
    }
}
