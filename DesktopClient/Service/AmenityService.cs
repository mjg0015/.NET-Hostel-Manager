using System.Collections.Generic;
using DesktopClient.Data;
using DesktopClient.Model;

namespace DesktopClient.Service
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
        private IRepository<BedType> _bedTypeRepo;

        private IRepository<BathroomType> _bathroomTypeRepo;

        public AmenityService()
        {
            _bedTypeRepo = new BedTypeRepository();
            _bathroomTypeRepo = new BathroomTypeRepository();
        }

        public bool CreateBathroomType(BathroomType bathroomType)
        {
            return _bathroomTypeRepo.InsertOrUpdate(bathroomType);
        }

        public bool CreateBedType(BedType bedType)
        {
            return _bedTypeRepo.InsertOrUpdate(bedType);
        }

        public List<BathroomType> GetAllBathroomTypes()
        {
            return _bathroomTypeRepo.FindAll();
        }

        public List<BedType> GetAllBedTypes()
        {
            return _bedTypeRepo.FindAll();
        }
    }
}
