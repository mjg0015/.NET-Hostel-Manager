using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopClient.Service;
using DesktopClient.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Test
{
    [TestClass]
    public class BedroomTests : DomainTests
    {
        IBedroomService _bedroomServ;

        public BedroomTests()
        {
            _bedroomServ = new BedroomService();
        }

        [TestMethod]
        public async Task GetAllBedrooms()
        {
            var bedrooms = await _bedroomServ.GetAllAsync();
            Assert.AreEqual(bedrooms.Count, 5);
        }

        [TestMethod]
        public async Task GetAvailableBedrooms()
        {
            var bedrooms = await _bedroomServ.GetAvailableAsync();
            Assert.AreEqual(bedrooms.Count, 4);
        }

        [TestMethod]
        public async Task GetFilteredBedrooms()
        {
            var filteredBedrooms1 = await _bedroomServ.GetFilteredAsync(1, 50, new BathroomType("Shared"), new BedType("Single"), true);
            Assert.AreEqual(filteredBedrooms1.Count, 2);
            Assert.IsTrue(filteredBedrooms1.Find(x => x.Number == 1) != null);
            Assert.IsTrue(filteredBedrooms1.Find(x => x.Number == 5) != null);
            Assert.IsTrue(filteredBedrooms1.Find(x => x.Number == 4) == null);
        }

        [TestMethod]
        public async Task CreateBedroom()
        {
            Bedroom bedroom = new Bedroom()
            {
                Number = 6,
                Price = 10.12,
                Size = 2,
                Available = true,
                BathroomType = new BathroomType("Shared"),
                BedType = new BedType("Double"),
            };

            bool result = await _bedroomServ.CreateOrUpdateAsync(bedroom);
            Assert.IsTrue(result);

            List<Bedroom> bedrooms = await _bedroomServ.GetAllAsync();
            Bedroom dbBedroom = bedrooms.Find(x => x.Number == bedroom.Number);

            Assert.IsNotNull(dbBedroom);
        }

        [TestMethod]
        public async Task UpdateBedroom()
        {
            int number = 5;
            double newPrice = 3.14;

            List<Bedroom> bedrooms = await _bedroomServ.GetAllAsync();
            Bedroom bedroom = bedrooms.Find(x => x.Number == number);

            bedroom.Price = newPrice;

            bool result = await _bedroomServ.CreateOrUpdateAsync(bedroom);
            Assert.IsTrue(result);

            bedrooms = await _bedroomServ.GetAllAsync();
            Bedroom dbBedroom = bedrooms.Find(x => x.Number == number);

            Assert.AreEqual(dbBedroom.Price, newPrice);
        }

        [TestMethod]
        public async Task RemoveBedroom()
        {
            int number = 3;

            bool removed = await _bedroomServ.RemoveAsync(new Bedroom() { Number = number });
            Assert.IsTrue(removed);

            List<Bedroom> bedrooms = await _bedroomServ.GetAllAsync();
            Bedroom dbBedroom = bedrooms.Find(x => x.Number == number);

            Assert.IsNull(dbBedroom);

            removed = await _bedroomServ.RemoveAsync(new Bedroom() { Number = 3 });
            Assert.IsFalse(removed);
        }

        /*[TestMethod]
        public async Task TestMethod1()
        {
            Bedroom bedroom1 = new Bedroom() {
                Number = 1,
                Price = 30.55,
                Size = 2,
                Available = true,
                BathroomType = new BathroomType("Shared"),
                BedType = new BedType("Double"),
            };

            Bedroom bedroom2 = new Bedroom()
            {
                Number = 2,
                Price = 30.15,
                Size = 3,
                Available = true,
                BathroomType = new BathroomType("Private"),
                BedType = new BedType("Single")
            };

            Bedroom bedroom3 = new Bedroom()
            {
                Number = 3,
                Price = 10.12,
                Size = 4,
                Available = true,
                BathroomType = new BathroomType("Shared"),
                BedType = new BedType("Single"),
            };

            Bedroom bedroom4 = new Bedroom()
            {
                Number = 4,
                Price = 12.12,
                Size = 1,
                Available = true,
                BathroomType = new BathroomType("Shared"),
                BedType = new BedType("Single")
            };

            IBedroomService bedroomServ = new BedroomService();

            bool b1 = await bedroomServ.CreateOrUpdateAsync(bedroom1);
            bool b2 = await bedroomServ.CreateOrUpdateAsync(bedroom2);
            bool b3 = await bedroomServ.CreateOrUpdateAsync(bedroom3);
            bool b4 = await bedroomServ.CreateOrUpdateAsync(bedroom4);

            Assert.IsTrue(b1);
            Assert.IsTrue(b2);
            Assert.IsTrue(b3);
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
                BathroomType = new BathroomType("Shared"),
                BedType = new BedType("Double"),
            };

            Bedroom bedroom2 = new Bedroom()
            {
                Number = 2,
                Price = 30.15,
                Size = 3,
                Available = true,
                BathroomType = new BathroomType("Private"),
                BedType = new BedType("Single")
            };

            Bedroom bedroom3 = new Bedroom()
            {
                Number = 3,
                Price = 10.12,
                Size = 4,
                Available = true,
                BathroomType = new BathroomType("Shared"),
                BedType = new BedType("Single"),
            };

            Bedroom bedroom4 = new Bedroom()
            {
                Number = 4,
                Price = 12.12,
                Size = 1,
                Available = true,
                BathroomType = new BathroomType("Shared"),
                BedType = new BedType("Single")
            };

            List<Guest> guestList = new List<Guest>();
            guestList.Add(guest1);

            CheckIn checkIn1 = new CheckIn()
            {
                ArrivingDate = new DateTime(),
                DepartureDate = new DateTime(),
                Guests = guestList,
                Bedroom = bedroom4,
                Active = true
            };

            guestList.Add(guest2);

            CheckIn checkIn2 = new CheckIn()
            {
                ArrivingDate = new DateTime(),
                DepartureDate = new DateTime(),
                Guests = guestList,
                Bedroom = bedroom1,
                Active = true
            };

            guestList.Add(guest3);

            CheckIn checkIn3 = new CheckIn()
            {
                ArrivingDate = new DateTime(),
                DepartureDate = new DateTime(),
                Guests = guestList,
                Bedroom = bedroom2,
                Active = true
            };

            guestList.Add(guest4);

            CheckIn checkIn4 = new CheckIn()
            {
                ArrivingDate = new DateTime(),
                DepartureDate = new DateTime(),
                Guests = guestList,
                Bedroom = bedroom3,
                Active = true
            };

            ICheckInService checkInService = new CheckInService();
            bool c1 = await checkInService.CreateAsync(checkIn1);
            bool c2 = await checkInService.CreateAsync(checkIn2);
            bool c3 = await checkInService.CreateAsync(checkIn3);
            bool c4 = await checkInService.CreateAsync(checkIn4);

            Assert.IsTrue(c1);
            Assert.IsTrue(c2);
            Assert.IsTrue(c3);
            Assert.IsTrue(c4);
        }

        [TestMethod]
        public async Task UpdateBedroom()
        {
            IBedroomService bedroomService = new BedroomService();
            Bedroom bedroom1 = new Bedroom()
            {
                Number = 1,
                Price = 30.56,
                Size = 2,
                Available = true,
                BathroomType = new BathroomType("Shared"),
                BedType = new BedType("Double"),
            };

            bool b1 = await bedroomService.CreateOrUpdateAsync(bedroom1);

            Assert.IsTrue(b1);
        }*/
    }
}
