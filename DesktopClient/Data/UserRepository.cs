﻿using DesktopClient.Model;
using MongoDB.Driver;

namespace DesktopClient.Data
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByName(string name);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository() : base("users")
        {
        }

        public User FindByName(string name)
        {
            User user = null;
            var found = _collection.Find(x => x.Name == name);
            if(found.Count() > 0)
            {
                user = found.First();
            }

            return user;
        }
    }
}
