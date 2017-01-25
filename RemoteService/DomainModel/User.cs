using Data;
using DomainModel.DataContracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RemoteService.Util;
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

        [BsonElement("role")]
        [BsonRepresentation(BsonType.String)]
        public Role Role { get; set; }

        public User(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CheckAsync()
        {
            try
            {
                User user = await _repository.FindByNameAndRoleAsync(Name, Role);
                return PasswordUtils.IsCorrect(user.Password, Password);
            }catch (Exception)
            {
                return false;
            }   
        }

        public async Task<bool> Register()
        {
            try
            {
                Password = PasswordUtils.Encode(Password);
                return await _repository.Save(this);
            }catch (Exception)
            {
                return false;
            }
        }
    }
}
