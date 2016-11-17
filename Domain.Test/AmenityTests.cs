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
    public class AmenityTests : DomainTests
    {
        private AmenityService _amenityServ;

        public AmenityTests()
        {
            _amenityServ = new AmenityService();
        }

        [TestMethod]
        public async Task GetAllAmenitiesTypes()
        {
            List<BedType> bedTypes = await _amenityServ.GetAllBedTypesAsync();
            Assert.AreEqual(bedTypes.Count, 3);

            List<BathroomType> bathroomTypes = await _amenityServ.GetAllBathroomTypesAsync();
            Assert.AreEqual(bathroomTypes.Count, 4);
        }

        [TestMethod]
        public async Task CreateAmenitiesTypes()
        {
            BedType bedType = new BedType("Ikea Bed");
            bool result = await _amenityServ.CreateBedTypeAsync(bedType);
            Assert.IsTrue(result);

            result = await _amenityServ.CreateBedTypeAsync(bedType);
            Assert.IsFalse(result);

            BathroomType bathroomType = new BathroomType("Private with Shower");
            result = await _amenityServ.CreateBathroomTypeAsync(bathroomType);
            Assert.IsTrue(result);

            result = await _amenityServ.CreateBathroomTypeAsync(bathroomType);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CreateAmenitiesFromBedroom()
        {
            BedType bedType = new BedType("Ikea Bed");
            BathroomType bathroomType = new BathroomType("Private with Shower");

            Bedroom bedroom = new Bedroom()
            {
                Number = 6,
                Available = true,
                BathroomType = bathroomType,
                BedType = bedType,
                Price = 10,
                Size = 2
            };

            IBedroomService bedroomServ = new BedroomService();
            await bedroomServ.CreateOrUpdateAsync(bedroom);

            List<BedType> bedTypes = await _amenityServ.GetAllBedTypesAsync();
            BedType dbBedType = bedTypes.Find(x => x.Name == bedType.Name);
            Assert.IsNotNull(dbBedType);

            List<BathroomType> bathroomTypes = await _amenityServ.GetAllBathroomTypesAsync();
            BathroomType dbBathroomType = bathroomTypes.Find(x => x.Name == bathroomType.Name);
            Assert.IsNotNull(dbBedType);
        }
    }
}
