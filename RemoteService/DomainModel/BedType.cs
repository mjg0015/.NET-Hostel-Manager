using Data;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainModel
{
    public class BedType
    {
        public const string COLLECTION_NAME = "bedTypes";

        private IAmenityRepository<BedType> _repository;

        [BsonId]
        public string Name { get; set; }

        public BedType(IAmenityRepository<BedType> repository)
        {
            _repository = repository;
        }

        public async Task<IList<BedType>> GetAllAsync()
        {
            try
            {
                return await _repository.FindAllAsync();
            }
            catch (Exception)
            {
                return new List<BedType>();
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

