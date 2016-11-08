using System;
using DesktopClient.Model;

namespace DesktopClient.Service
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
