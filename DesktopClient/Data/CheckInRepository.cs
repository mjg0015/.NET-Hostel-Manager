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

        public async new Task<bool> InsertOrUpdateAsync(CheckIn checkIn)
        {
            checkIn.GuestsRef = new List<string>();

            foreach (Guest guest in checkIn.Guests)
            {
                bool guestInserted = await _guestRepo.InsertOrUpdateAsync(guest);
                /*if (!guestInserted)
                {
                    return false;
                }*/
                checkIn.GuestsRef.Add(guest.DocumentId);
            }

            checkIn.BedroomRef = checkIn.Bedroom.Number;

            return await base.InsertOrUpdateAsync(checkIn);
        }

        public async Task<List<CheckIn>> FindWithPendingCheckOutAsync()
        {
            List<CheckIn> checkIns = await _collection.Find(x => x.Bedroom.Available == false).ToListAsync();

            foreach(CheckIn checkIn in checkIns)
            {
                Bedroom bedroom = await _bedroomRepo.FindByIdAsync(checkIn.BedroomRef);

                List<Guest> guests = new List<Guest>();
                foreach(string guestRef in checkIn.GuestsRef)
                {
                    Guest guest = await _guestRepo.FindByIdAsync(guestRef);
                    guests.Add(guest);
                }
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
