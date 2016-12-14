using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Data;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using DomainModel.DataContracts;

namespace DomainModel
{
    public class Guest
    {
        public const string COLLECTION_NAME = "guests";

        private IGuestRepository _repository;

        [BsonId]
        public string DocumentId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [BsonElement("sex")]
        [BsonRepresentation(BsonType.String)]
        public Sex Sex { get; set; }

        public Guest(IGuestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guest> GetByDocumentId(string documentId)
        {
            try
            {
                return await _repository.FindByIdAsync(documentId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CreateOrUpdateAsync()
        {
            try
            {
                return await _repository.InsertOrUpdateAsync(this);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
