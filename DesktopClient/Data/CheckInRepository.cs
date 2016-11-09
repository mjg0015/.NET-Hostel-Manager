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
        public CheckInRepository() : base("checkIns")
        {
        }

        public async Task<List<CheckIn>> FindWithPendingCheckOutAsync()
        {
            List<CheckIn> checkIns = await _collection.Find(x => x.Bedroom.Available == false).ToListAsync();
            return checkIns;
        }

        public async Task<bool> RemoveAsync(CheckIn checkIn)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == checkIn.Id);
            return result.DeletedCount > 0;
        }
    }
}
