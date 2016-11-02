using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IAmenityService
    {
        List<BedType> GetAllBedTypes();

        List<BathroomType> GetAllBathroomTypes();

        bool CreateBedType(BedType bedType);

        bool CreateBathroomType(BathroomType bathroomType);
    }

    public class AmenityService : IAmenityService
    {
        public bool CreateBathroomType(BathroomType bathroomType)
        {
            throw new NotImplementedException();
        }

        public bool CreateBedType(BedType bedType)
        {
            throw new NotImplementedException();
        }

        public List<BathroomType> GetAllBathroomTypes()
        {
            throw new NotImplementedException();
        }

        public List<BedType> GetAllBedTypes()
        {
            throw new NotImplementedException();
        }
    }
}
