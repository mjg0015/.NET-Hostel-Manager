using System;
using DomainModel.DataContracts;

namespace DesktopClient.EventArgsExtenctions
{
    class CheckInEventArgs:EventArgs
    {
        public CheckInDto CheckIn { get; private set; }

        public CheckInEventArgs(CheckInDto checkIn)
        {
            CheckIn = checkIn;
        }
    }
}
