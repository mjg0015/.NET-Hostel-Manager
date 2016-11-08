using System.Collections.Generic;
using DesktopClient.Model;
using MongoDB.Driver;

namespace DesktopClient.Data
{
    public interface ICheckInRepository : IRepository<CheckIn>
    {
        List<CheckIn> FindWithPendingCheckOut();
    }

    public class CheckInRepository : Repository<CheckIn>, ICheckInRepository
    {
        public CheckInRepository() : base("checkIns")
        {
        }

        public List<CheckIn> FindWithPendingCheckOut()
        {
            List<CheckIn> checkIns = _collection.Find(x => x.Bedroom.Available == false).ToList();
            return checkIns;
        }
    }
}
