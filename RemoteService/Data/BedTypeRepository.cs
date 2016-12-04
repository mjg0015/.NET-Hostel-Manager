using System.Threading.Tasks;
using DomainModel;
using MongoDB.Driver;

namespace Data
{
    public class BedTypeRepository : Repository<BedType>, IAmenityRepository<BedType>
    {
        public BedTypeRepository(IMongoDatabase db) : base(db, BedType.COLLECTION_NAME)
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
