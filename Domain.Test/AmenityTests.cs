using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteService.Service;
using DomainModel.DataContracts;

namespace Domain.Test
{
    [TestClass]
    public class AmenityTests : DomainTests
    {
        private IAmenityService _amenityServ;

        public AmenityTests()
        {
            _amenityServ = new AmenityService();
        }

        [TestMethod]
        public async Task GetAllAmenitiesTypes()
        {
            IList<BedTypeDto> bedTypesDto = await _amenityServ.GetAllBedTypesAsync();
            Assert.AreEqual(bedTypesDto.Count, 3);

            IList<BathroomTypeDto> bathroomTypesDto = await _amenityServ.GetAllBathroomTypesAsync();
            Assert.AreEqual(bathroomTypesDto.Count, 4);
        }

        [TestMethod]
        public async Task CreateAmenitiesTypes()
        {
            BedTypeDto bedTypeDto = new BedTypeDto() { Name = "Ikea Bed" };
            bool result = await _amenityServ.CreateBedTypeAsync(bedTypeDto);
            Assert.IsTrue(result);

            result = await _amenityServ.CreateBedTypeAsync(bedTypeDto);
            Assert.IsFalse(result);

            BathroomTypeDto bathroomTypeDto = new BathroomTypeDto() { Name = "Private with Shower" };
            result = await _amenityServ.CreateBathroomTypeAsync(bathroomTypeDto);
            Assert.IsTrue(result);

            result = await _amenityServ.CreateBathroomTypeAsync(bathroomTypeDto);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CreateAmenitiesFromBedroom()
        {
            BedTypeDto bedType = new BedTypeDto() { Name = "Ikea Bed" };
            BathroomTypeDto bathroomType = new BathroomTypeDto() { Name = "Private with Shower" };

            BedroomDto bedroom = new BedroomDto()
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

            List<BedTypeDto> bedTypes = new List<BedTypeDto>(await _amenityServ.GetAllBedTypesAsync());
            BedTypeDto dbBedType = bedTypes.Find(x => x.Name == bedType.Name);
            Assert.IsNotNull(dbBedType);

            List<BathroomTypeDto> bathroomTypes = new List<BathroomTypeDto>(await _amenityServ.GetAllBathroomTypesAsync());
            BathroomTypeDto dbBathroomType = bathroomTypes.Find(x => x.Name == bathroomType.Name);
            Assert.IsNotNull(dbBedType);
        }
    }
}
