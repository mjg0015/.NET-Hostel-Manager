using DomainModel;
using MongoDB.Driver;
using System.Threading.Tasks;
using DomainModel.DataContracts;

namespace Data
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByNameAndRoleAsync(string name, Role role);

        Task<bool> Save(User user);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository(IMongoDatabase db) : base(db, User.COLLECTION_NAME)
        {
        }

        public async Task<User> FindByNameAndRoleAsync(string name, Role role)
        {
            User user = null;
            var found = _collection.Find(x => x.Name == name && x.Role == role);
            if(found.Count() > 0)
            {
                user = await found.FirstAsync();
            }

            return user;
        }

        public async Task<bool> Save(User user)
        {
            bool status = await InsertAsync(user);
            return status;
        }
    }
}
