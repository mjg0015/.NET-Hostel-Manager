using System.Threading.Tasks;
using DesktopClient.Model;
using MongoDB.Driver;

namespace DesktopClient.Data
{
    public class BedTypeRepository : Repository<BedType>, IAmenityRepository<BedType>
    {
        public BedTypeRepository() : base("bedType")
        {
        }

        public async Task<BedType> FindByTypeAsync(string type)
        {
            BedType bedType = null;
            var found = _collection.Find(x => x.Name == type);
            if (found.Count() > 0)
            {
                bedType = await found.FirstAsync();
            }

            return bedType;
        }
    }
}
