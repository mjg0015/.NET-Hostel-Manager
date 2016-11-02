using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IGuestService
    {
        Guest FindGuestById(string id);

        bool CreateOrUpdate(Guest guest);
    }

    public class GuestService : IGuestService
    {
        public bool CreateOrUpdate(Guest guest)
        {
            throw new NotImplementedException();
        }

        public Guest FindGuestById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
