using System;
using DesktopClient.Model;

namespace DesktopClient.Service
{
    public interface ICheckInService
    {
        bool Create(CheckIn checkIn);

        bool DoCheckOut(CheckIn checkIn);
    }

    public class CheckInService : ICheckInService
    {


        public bool Create(CheckIn checkIn)
        {
            throw new NotImplementedException();
        }

        public bool DoCheckOut(CheckIn checkIn)
        {
            throw new NotImplementedException();
        }
    }
}
