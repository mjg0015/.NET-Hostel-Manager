using DesktopClient.Model;

namespace DesktopClient.Data
{
    public class BedTypeRepository : Repository<BedType>
    {
        public BedTypeRepository() : base("bedType")
        {
        }
    }
}
