using DesktopClient.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByNameAsync(string name);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository() : base("users")
        {
        }

        public async Task<User> FindByNameAsync(string name)
        {
            User user = null;
            var found = _collection.Find(x => x.Name == name);
            if(found.Count() > 0)
            {
                user = await found.FirstAsync();
            }

            return user;
        }
    }
}
