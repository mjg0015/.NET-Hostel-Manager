using Data;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainModel
{
    public class BathroomType
    {
        public const string COLLECTION_NAME = "bathroomTypes";

        private IAmenityRepository<BathroomType> _repository;

        [BsonId]
        public string Name { get; set; }

        public BathroomType(IAmenityRepository<BathroomType> repository)
        {
            _repository = repository;
        }

        public async Task<IList<BathroomType>> GetAllAsync()
        {
            try
            {
                return await _repository.FindAllAsync();
            }
            catch (Exception)
            {
                return new List<BathroomType>();
            }
        }

        public async Task<bool> CreateAsync()
        {
            try
            {
                return await _repository.InsertAsync(this);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
