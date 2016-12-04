using DomainModel.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            IList<BedTypeDTO> bedTypesDTO = await _amenityServ.GetAllBedTypesAsync();
            Assert.AreEqual(bedTypesDTO.Count, 3);

            IList<BathroomTypeDTO> bathroomTypesDTO = await _amenityServ.GetAllBathroomTypesAsync();
            Assert.AreEqual(bathroomTypesDTO.Count, 4);
        }

        [TestMethod]
        public async Task CreateAmenitiesTypes()
        {
            BedTypeDTO bedTypeDTO = new BedTypeDTO() { Name = "Ikea Bed" };
            bool result = await _amenityServ.CreateBedTypeAsync(bedTypeDTO);
            Assert.IsTrue(result);

            result = await _amenityServ.CreateBedTypeAsync(bedTypeDTO);
            Assert.IsFalse(result);

            BathroomTypeDTO bathroomTypeDTO = new BathroomTypeDTO() { Name = "Private with Shower" };
            result = await _amenityServ.CreateBathroomTypeAsync(bathroomTypeDTO);
            Assert.IsTrue(result);

            result = await _amenityServ.CreateBathroomTypeAsync(bathroomTypeDTO);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CreateAmenitiesFromBedroom()
        {
            BedTypeDTO bedType = new BedTypeDTO() { Name = "Ikea Bed" };
            BathroomTypeDTO bathroomType = new BathroomTypeDTO() { Name = "Private with Shower" };

            BedroomDTO bedroom = new BedroomDTO()
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

            List<BedTypeDTO> bedTypes = new List<BedTypeDTO>(await _amenityServ.GetAllBedTypesAsync());
            BedTypeDTO dbBedType = bedTypes.Find(x => x.Name == bedType.Name);
            Assert.IsNotNull(dbBedType);

            List<BathroomTypeDTO> bathroomTypes = new List<BathroomTypeDTO>(await _amenityServ.GetAllBathroomTypesAsync());
            BathroomTypeDTO dbBathroomType = bathroomTypes.Find(x => x.Name == bathroomType.Name);
            Assert.IsNotNull(dbBedType);
        }
    }
}
