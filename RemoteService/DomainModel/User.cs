using Data;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Threading.Tasks;

namespace DomainModel
{
    public class User
    {
        public const string COLLECTION_NAME = "users";

        private IUserRepository _repository;

        [BsonId]
        public string Name { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        public User(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CheckAsync()
        {
            try
            {
                User user = await _repository.FindByNameAsync(Name);
                return Password == user.Password;
            }catch (Exception)
            {
                return false;
            }   
        }
    }
}
