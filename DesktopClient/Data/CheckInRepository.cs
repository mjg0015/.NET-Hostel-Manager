using System;
using System.Collections.Generic;
using DesktopClient.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public interface ICheckInRepository : IRepository<CheckIn>
    {
        Task<List<CheckIn>> FindWithPendingCheckOutAsync();

        Task<bool> InsertOrUpdateAsync(CheckIn checkIn);

        Task<bool> RemoveAsync(CheckIn checkIn);
    }

    public class CheckInRepository : Repository<CheckIn>, ICheckInRepository
    {
        private IGuestRepository _guestRepo;

        private IBedroomRepository _bedroomRepo;

        public CheckInRepository() : base("checkIns")
        {
            _guestRepo = new GuestRepository();
            _bedroomRepo = new BedroomRepository();
        }

        public async Task<bool> InsertOrUpdateAsync(CheckIn checkIn)
        {
            checkIn.GuestsRef = new List<string>();

            foreach (Guest guest in checkIn.Guests)
            {
                await _guestRepo.InsertOrUpdateAsync(guest);
                checkIn.GuestsRef.Add(guest.DocumentId);
            }

            checkIn.BedroomRef = checkIn.Bedroom.Number;
            await _bedroomRepo.InsertOrUpdateAsync(checkIn.Bedroom);

            bool status = await base.InsertAsync(checkIn);
            if (!status)
            {
                var filter = Builders<CheckIn>.Filter.Eq("Id", checkIn.Id);
                var result = await _collection.ReplaceOneAsync(filter, checkIn);
                status = result.ModifiedCount > 0;
            }

            return status;
        }

        public async Task<List<CheckIn>> FindWithPendingCheckOutAsync()
        {
            List<CheckIn> checkIns = await _collection.Find(x => x.Active == true).ToListAsync();

            foreach(CheckIn checkIn in checkIns)
            {
                Bedroom bedroom = await _bedroomRepo.FindByIdAsync(checkIn.BedroomRef);

                List<Guest> guests = new List<Guest>();
                foreach(string guestRef in checkIn.GuestsRef)
                {
                    Guest guest = await _guestRepo.FindByIdAsync(guestRef);
                    guests.Add(guest);
                }

                checkIn.Bedroom = bedroom;
                checkIn.Guests = guests;
            }

            return checkIns;
        }

        public async Task<bool> RemoveAsync(CheckIn checkIn)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == checkIn.Id);
            return result.DeletedCount > 0;
        }
    }
}
