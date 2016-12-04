using DomainModel;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Data
{
    public class BathroomTypeRepository : Repository<BathroomType>, IAmenityRepository<BathroomType>
    {
        public BathroomTypeRepository(IMongoDatabase db) : base(db, BathroomType.COLLECTION_NAME)
        {
        }

        public async Task<BathroomType> FindByTypeAsync(string type)
        {
            BathroomType bathroomType = null;
            var found = _collection.Find(x => x.Name == type);
            if (found.Count() > 0)
            {
                bathroomType = await found.FirstAsync();
            }

            return bathroomType;
        }
    }
}
