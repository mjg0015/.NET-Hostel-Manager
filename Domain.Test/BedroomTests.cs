using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Service;
using DomainModel.DTO;

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
            IList<BedroomDTO> bedrooms = await _bedroomServ.GetAllAsync();
            Assert.AreEqual(bedrooms.Count, 5);
        }

        [TestMethod]
        public async Task GetAvailableBedrooms()
        {
            IList<BedroomDTO> bedrooms = await _bedroomServ.GetAvailableAsync();
            Assert.AreEqual(bedrooms.Count, 4);
        }

        /*[TestMethod]
        public async Task GetFilteredBedrooms()
        {
            var filteredBedrooms1 = await _bedroomServ.GetFilteredAsync(1, 50, new BathroomType("Shared"), new BedType("Single"), true);
            Assert.AreEqual(filteredBedrooms1.Count, 2);
            Assert.IsTrue(filteredBedrooms1.Find(x => x.Number == 1) != null);
            Assert.IsTrue(filteredBedrooms1.Find(x => x.Number == 5) != null);
            Assert.IsTrue(filteredBedrooms1.Find(x => x.Number == 4) == null);
        }*/

        [TestMethod]
        public async Task CreateBedroom()
        {
            BedroomDTO bedroom = new BedroomDTO()
            {
                Number = 6,
                Price = 10.12,
                Size = 2,
                Available = true,
                BathroomType = new BathroomTypeDTO() { Name = "Shared" },
                BedType = new BedTypeDTO() { Name= "Double" },
            };

            bool result = await _bedroomServ.CreateOrUpdateAsync(bedroom);
            Assert.IsTrue(result);

            List<BedroomDTO> bedrooms = new List<BedroomDTO>(await _bedroomServ.GetAllAsync());
            BedroomDTO dbBedroom = bedrooms.Find(x => x.Number == bedroom.Number);

            Assert.IsNotNull(dbBedroom);
        }

        [TestMethod]
        public async Task UpdateBedroom()
        {
            int number = 5;
            double newPrice = 3.14;

            List<BedroomDTO> bedrooms = new List<BedroomDTO>(await _bedroomServ.GetAllAsync());
            BedroomDTO bedroom = bedrooms.Find(x => x.Number == number);

            bedroom.Price = newPrice;

            bool result = await _bedroomServ.CreateOrUpdateAsync(bedroom);
            Assert.IsTrue(result);

            bedrooms = new List<BedroomDTO>(await _bedroomServ.GetAllAsync());
            BedroomDTO dbBedroom = bedrooms.Find(x => x.Number == number);

            Assert.AreEqual(dbBedroom.Price, newPrice);
        }

        [TestMethod]
        public async Task RemoveBedroom()
        {
            int number = 3;

            bool removed = await _bedroomServ.RemoveAsync(new BedroomDTO() { Number = number });
            Assert.IsTrue(removed);

            List<BedroomDTO> bedrooms = new List<BedroomDTO>(await _bedroomServ.GetAllAsync());
            BedroomDTO dbBedroom = bedrooms.Find(x => x.Number == number);

            Assert.IsNull(dbBedroom);

            removed = await _bedroomServ.RemoveAsync(new BedroomDTO() { Number = 3 });
            Assert.IsFalse(removed);
        }
    }
}
