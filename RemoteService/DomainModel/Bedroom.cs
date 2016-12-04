using Data;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Bedroom
    {
        public const string COLLECTION_NAME = "bedrooms";

        private IBedroomRepository _repository;

        private IAmenityRepository<BathroomType> _bathroomTypeRepository;

        private IAmenityRepository<BedType> _bedTypeRepository;

        [BsonId]
        public int Number { get; set; }

        [BsonElement("price")]
        public double Price { get ; set; }

        [BsonElement("size")]
        public int Size { get; set; }

        [BsonElement("available")]
        public bool Available { get; set; }

        [BsonIgnore]
        public BathroomType BathroomType { get; set; }

        [BsonElement("bathroomType")]
        public string BathroomTypeRef { get; set; }

        [BsonIgnore]
        public BedType BedType { get; set; }

        [BsonElement("bedType")]
        public string BedTypeRef { get; set; }

        public Bedroom(IBedroomRepository repository, 
            IAmenityRepository<BathroomType> bathroomTypeRepository, 
            IAmenityRepository<BedType> bedTypeRepository)
        {
            _repository = repository;
            _bathroomTypeRepository = bathroomTypeRepository;
            _bedTypeRepository = bedTypeRepository;
        }

        public async Task<bool> CreateOrUpdateAsync()
        {
            try
            {
                await _bathroomTypeRepository.InsertAsync(BathroomType);
                await _bedTypeRepository.InsertAsync(BedType);
                return await _repository.InsertOrUpdateAsync(this);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Bedroom> GetByNumber(int number)
        {
            try
            {
                Bedroom bedroom = await _repository.FindByIdAsync(number);
                return await FillAmenitiesUtil(bedroom);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IList<Bedroom>> GetAllAsync()
        {
            try
            {
                IList<Bedroom> bedrooms = await _repository.FindAllAsync();
                return await FillAmenitiesUtil(bedrooms);
            }
            catch (Exception)
            {
                return new List<Bedroom>();
            }
        }

        public async Task<IList<Bedroom>> GetAvailableAsync()
        {
            try
            {
                IList<Bedroom> bedrooms = await _repository.FindByAvailabilityAsync(true);
                return await FillAmenitiesUtil(bedrooms);
            }
            catch (Exception)
            {
                return new List<Bedroom>();
            }
        }

        public async Task<bool> RemoveAsync()
        {
            try
            {
                return await _repository.RemoveAsync(this);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<IList<Bedroom>> FillAmenitiesUtil(IList<Bedroom> bedrooms)
        {
            IList<Bedroom> bedroomsFilled = new List<Bedroom>();

            foreach (Bedroom bedroom in bedrooms)
            {
                bedroomsFilled.Add(await FillAmenitiesUtil(bedroom));
            }

            return bedroomsFilled;
        }

        private async Task<Bedroom> FillAmenitiesUtil(Bedroom bedroom)
        {
            bedroom.BathroomType = await _bathroomTypeRepository.FindByTypeAsync(bedroom.BathroomTypeRef);
            bedroom.BedType = await _bedTypeRepository.FindByTypeAsync(bedroom.BedTypeRef);
            return bedroom;
        }
    }
}
