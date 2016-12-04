using System.Collections.Generic;
using DomainModel;
using MongoDB.Driver;
using System.Threading.Tasks;
using System;

namespace Data
{
    public interface ICheckInRepository : IRepository<CheckIn>
    {
        Task<IList<CheckIn>> FindWithPendingCheckOutAsync();

        Task<IList<CheckIn>> FindBetweenDatesAsync(DateTime startDate, DateTime endDate);

        Task<bool> InsertOrUpdateAsync(CheckIn checkIn);

        Task<bool> RemoveAsync(CheckIn checkIn);
    }

    public class CheckInRepository : Repository<CheckIn>, ICheckInRepository
    {

        public CheckInRepository(IMongoDatabase db) : base(db, CheckIn.COLLECTION_NAME)
        {
        }

        public async Task<bool> InsertOrUpdateAsync(CheckIn checkIn)
        {
            checkIn.GuestsRef = new List<string>();

            foreach (Guest guest in checkIn.Guests)
            {
                checkIn.GuestsRef.Add(guest.DocumentId);
            }

            checkIn.BedroomRef = checkIn.Bedroom.Number;

            bool status = await InsertAsync(checkIn);
            if (!status)
            {
                var filter = Builders<CheckIn>.Filter.Eq("Id", checkIn.Id);
                var result = await _collection.ReplaceOneAsync(filter, checkIn);
                status = result.ModifiedCount > 0;
            }

            return status;
        }

        public async Task<IList<CheckIn>> FindWithPendingCheckOutAsync()
        {
            IList<CheckIn> checkIns = await _collection.Find(x => x.Active == true).ToListAsync();
            return checkIns;
        }

        public async Task<bool> RemoveAsync(CheckIn checkIn)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == checkIn.Id);
            return result.DeletedCount > 0;
        }

        public async Task<IList<CheckIn>> FindBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            IList<CheckIn> checkIns = await _collection.Find(
                x => x.ArrivingDate >= startDate && x.ArrivingDate <= endDate).ToListAsync();
            return checkIns;
        }
    }
}
