using Domain.Model;
using Domain.Service;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Domain.Data
{
    public interface IUserRepository
    {
        User FindByName(string name);
    }

    public class UserRepository : IUserRepository
    {
        private IMongoDatabase _db;
        
        public UserRepository()
        {
            _db = PersistenceService.GetDatabase();
        }

        public User FindByName(string name)
        {
            User user = null;
            try
            {
                var collection = _db.GetCollection<User>("users");
                user = collection.Find(x => x.Name == name).First();
            }catch(Exception)
            {

            }

            return user;
        }
    }
}
