using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopClient.Service;
using DesktopClient.Model;
using System.Threading.Tasks;

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
    }
}
