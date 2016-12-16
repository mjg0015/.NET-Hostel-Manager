using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Data;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DomainModel
{
    public class CheckIn
    {
        public const string COLLECTION_NAME = "checkIns";

        private ICheckInRepository _repository;

        private IGuestRepository _guestRepository;

        private IBedroomRepository _bedroomRepository;

        private IAmenityRepository<BathroomType> _bathroomTypeRepository;

        private IAmenityRepository<BedType> _bedTypeRepository;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("arrivingDate")]
        public DateTime ArrivingDate { get; set; }

        [BsonElement("departureDate")]
        public DateTime DepartureDate { get; set; }

        [BsonIgnore]
        public IList<Guest> Guests { get; set; }

        [BsonElement("guests")]
        public IList<string> GuestsRef { get; set; }

        [BsonIgnore]
        public Bedroom Bedroom { get; set; }

        [BsonElement("bedroom")]
        public int BedroomRef { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        public CheckIn(ICheckInRepository repository, IGuestRepository guestRepository,
            IBedroomRepository bedroomRepository, IAmenityRepository<BathroomType> bathroomTypeRepository, 
            IAmenityRepository<BedType> bedTypeRepository)
        {
            _repository = repository;
            _guestRepository = guestRepository;
            _bedroomRepository = bedroomRepository;
            _bathroomTypeRepository = bathroomTypeRepository;
            _bedTypeRepository = bedTypeRepository;
        }

        public async Task<IList<CheckIn>> GetPendingCheckOutAsync()
        {
            try
            {
                IList<CheckIn> checkIns = await _repository.FindWithPendingCheckOutAsync();
                return await FillCheckInGuestsAndBedroomUtil(checkIns);
            }
            catch (Exception)
            {
                return new List<CheckIn>();
            }
        }

        public async Task<IList<CheckIn>> GetBetweenDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                IList<CheckIn> checkIns = await _repository.FindBetweenDatesAsync(startDate, endDate);
                return await FillCheckInGuestsAndBedroomUtil(checkIns);
            }catch (Exception)
            {
                return new List<CheckIn>();
            }
        }

        public async Task<IList<CheckIn>> GetAll()
        {
            try
            {
                IList<CheckIn> checkIns = await _repository.FindAllAsync();
                return await FillCheckInGuestsAndBedroomUtil(checkIns);
            }
            catch (Exception)
            {
                return new List<CheckIn>();
            }
        }

        public async Task<bool> CreateAsync()
        {
            Active = true;
            Bedroom.Available = false;
            Price = Bedroom.Price;

            try
            {
                foreach(Guest guest in Guests)
                {
                    await _guestRepository.InsertOrUpdateAsync(guest);
                }

                await _bedroomRepository.InsertOrUpdateAsync(Bedroom);

                bool created = await _repository.InsertOrUpdateAsync(this);
                return created;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DoCheckOutAsync()
        {
            Active = false;
            Bedroom.Available = true;
            try
            {
                await _bedroomRepository.InsertOrUpdateAsync(Bedroom);
                bool updated = await _repository.InsertOrUpdateAsync(this);
                return updated;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<IList<CheckIn>> FillCheckInGuestsAndBedroomUtil(IList<CheckIn> checkIns)
        {
            IList<CheckIn> checkInsFilled = new List<CheckIn>();

            foreach (CheckIn checkIn in checkIns)
            {
                checkInsFilled.Add(await FillCheckInGuestsAndBedroomUtil(checkIn));
            }

            return checkIns;
        }

        private async Task<CheckIn> FillCheckInGuestsAndBedroomUtil(CheckIn checkIn)
        {
            Bedroom bedroom = new Bedroom(_bedroomRepository, _bathroomTypeRepository, _bedTypeRepository);
            checkIn.Bedroom = await bedroom.GetByNumber(checkIn.BedroomRef);
            checkIn.Guests = new List<Guest>();
            foreach (string guestRef in checkIn.GuestsRef)
            {
                checkIn.Guests.Add(await _guestRepository.FindByIdAsync(guestRef));
            }
            return checkIn;
        }
    }
}
