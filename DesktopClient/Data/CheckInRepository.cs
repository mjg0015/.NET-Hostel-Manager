using Domain.Model;
using Domain.Service;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
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
