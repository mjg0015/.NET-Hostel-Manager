using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Service;
using DomainModel.DataContracts;
using RemoteService.Service;

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
            IList<BedroomDto> bedrooms = await _bedroomServ.GetAllAsync();
            Assert.AreEqual(bedrooms.Count, 5);
        }

        [TestMethod]
        public async Task GetAvailableBedrooms()
        {
            IList<BedroomDto> bedrooms = await _bedroomServ.GetAvailableAsync();
            Assert.AreEqual(bedrooms.Count, 4);
        }

        [TestMethod]
        public async Task CreateBedroom()
        {
            BedroomDto bedroom = new BedroomDto()
            {
                Number = 6,
                Price = 10.12,
                Size = 2,
                Available = true,
                BathroomType = new BathroomTypeDto() { Name = "Shared" },
                BedType = new BedTypeDto() { Name= "Double" },
            };

            bool result = await _bedroomServ.CreateOrUpdateAsync(bedroom);
            Assert.IsTrue(result);

            List<BedroomDto> bedrooms = new List<BedroomDto>(await _bedroomServ.GetAllAsync());
            BedroomDto dbBedroom = bedrooms.Find(x => x.Number == bedroom.Number);

            Assert.IsNotNull(dbBedroom);
        }

        [TestMethod]
        public async Task UpdateBedroom()
        {
            int number = 5;
            double newPrice = 3.14;

            List<BedroomDto> bedrooms = new List<BedroomDto>(await _bedroomServ.GetAllAsync());
            BedroomDto bedroom = bedrooms.Find(x => x.Number == number);

            bedroom.Price = newPrice;

            bool result = await _bedroomServ.CreateOrUpdateAsync(bedroom);
            Assert.IsTrue(result);

            bedrooms = new List<BedroomDto>(await _bedroomServ.GetAllAsync());
            BedroomDto dbBedroom = bedrooms.Find(x => x.Number == number);

            Assert.AreEqual(dbBedroom.Price, newPrice);
        }

        [TestMethod]
        public async Task RemoveBedroom()
        {
            int number = 3;

            bool removed = await _bedroomServ.RemoveAsync(new BedroomDto() { Number = number });
            Assert.IsTrue(removed);

            List<BedroomDto> bedrooms = new List<BedroomDto>(await _bedroomServ.GetAllAsync());
            BedroomDto dbBedroom = bedrooms.Find(x => x.Number == number);

            Assert.IsNull(dbBedroom);

            removed = await _bedroomServ.RemoveAsync(new BedroomDto() { Number = 3 });
            Assert.IsFalse(removed);
        }
    }
}
