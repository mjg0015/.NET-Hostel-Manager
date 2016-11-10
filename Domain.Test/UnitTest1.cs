using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopClient.Service;
using DesktopClient.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            Bedroom bedroom1 = new Bedroom() {
                Number = 1,
                Price = 30.55,
                Size = 2,
                Available = true,
                BathroomType = new BathroomType() { Name = "Shared" },
                BedType = new BedType() { Name = "Double" }
            };

            Bedroom bedroom2 = new Bedroom()
            {
                Number = 2,
                Price = 30.15,
                Size = 3,
                Available = true,
                BathroomType = new BathroomType() { Name = "Private" },
                BedType = new BedType() { Name = "Single" }
            };

            Bedroom bedroom3 = new Bedroom()
            {
                Number = 3,
                Price = 10.12,
                Size = 4,
                Available = true,
                BathroomType = new BathroomType() { Name = "Shared" },
                BedType = new BedType() { Name = "Single" }
            };

            Bedroom bedroom4 = new Bedroom()
            {
                Number = 4,
                Price = 12.12,
                Size = 1,
                Available = true,
                BathroomType = new BathroomType() { Name = "Shared" },
                BedType = new BedType() { Name = "Single" }
            };

            IBedroomService bedroomServ = new BedroomService();

            bool b1 = await bedroomServ.CreateOrUpdateAsync(bedroom1);
            bool b2 = await bedroomServ.CreateOrUpdateAsync(bedroom2);
            bool b3 = await bedroomServ.CreateOrUpdateAsync(bedroom3);
            bool b4 = await bedroomServ.CreateOrUpdateAsync(bedroom4);

            Assert.IsTrue(b1);
            Assert.IsTrue(b2);
            Assert.IsTrue(b3);
        }


        [TestMethod]
        public async Task CreateCheckIns()
        {  
            Guest guest1 = new Guest()
            {
                DocumentId = "123456A",
                Name = "Carl",
                Surname = "Marx",
                BirthDate = new DateTime(),
                Sex = Sex.MALE
            };

            Guest guest2 = new Guest()
            {
                DocumentId = "123456B",
                Name = "Leo",
                Surname = "Messi",
                BirthDate = new DateTime(),
                Sex = Sex.MALE
            };

            Guest guest3 = new Guest()
            {
                DocumentId = "123456C",
                Name = "Frederic",
                Surname = "Chopin",
                BirthDate = new DateTime(),
                Sex = Sex.MALE
            };

            Guest guest4 = new Guest()
            {
                DocumentId = "123456D",
                Name = "Ian",
                Surname = "Wallace",
                BirthDate = new DateTime(),
                Sex = Sex.MALE
            };

            Bedroom bedroom1 = new Bedroom()
            {
                Number = 1,
                Price = 30.55,
                Size = 2,
                Available = true,
                BathroomType = new BathroomType() { Name = "Shared" },
                BedType = new BedType() { Name = "Double" }
            };

            Bedroom bedroom2 = new Bedroom()
            {
                Number = 2,
                Price = 30.15,
                Size = 3,
                Available = true,
                BathroomType = new BathroomType() { Name = "Private" },
                BedType = new BedType() { Name = "Single" }
            };

            Bedroom bedroom3 = new Bedroom()
            {
                Number = 3,
                Price = 10.12,
                Size = 4,
                Available = true,
                BathroomType = new BathroomType() { Name = "Shared" },
                BedType = new BedType() { Name = "Single" }
            };

            Bedroom bedroom4 = new Bedroom()
            {
                Number = 4,
                Price = 12.12,
                Size = 1,
                Available = true,
                BathroomType = new BathroomType() { Name = "Shared" },
                BedType = new BedType() { Name = "Single" }
            };

            List<Guest> guestList = new List<Guest>();
            guestList.Add(guest1);

            CheckIn checkIn1 = new CheckIn()
            {
                ArrivingDate = new DateTime(),
                DepartureDate = new DateTime(),
                Guests = guestList,
                Bedroom = bedroom4
            };

            guestList.Add(guest2);

            CheckIn checkIn2 = new CheckIn()
            {
                ArrivingDate = new DateTime(),
                DepartureDate = new DateTime(),
                Guests = guestList,
                Bedroom = bedroom1
            };

            guestList.Add(guest3);

            CheckIn checkIn3 = new CheckIn()
            {
                ArrivingDate = new DateTime(),
                DepartureDate = new DateTime(),
                Guests = guestList,
                Bedroom = bedroom2
            };

            guestList.Add(guest4);

            CheckIn checkIn4 = new CheckIn()
            {
                ArrivingDate = new DateTime(),
                DepartureDate = new DateTime(),
                Guests = guestList,
                Bedroom = bedroom3
            };

            ICheckInService checkInService = new CheckInService();
            bool c1 = await checkInService.CreateAsync(checkIn1);
            bool c2 = await checkInService.CreateAsync(checkIn2);
            bool c3 = await checkInService.CreateAsync(checkIn3);
            bool c4 = await checkInService.CreateAsync(checkIn4);

            List<CheckIn> checkIns = await checkInService.GetPendingCheckOutAsync();
            Assert.Equals(checkIns.Count, 4);

            Assert.IsTrue(c1);
            Assert.IsTrue(c2);
            Assert.IsTrue(c3);
            Assert.IsTrue(c4);
        }
    }
}
