using System;
using DesktopClient.Model;

namespace DesktopClient.EventArgsExtenctions
{
    class CheckInEventArgs:EventArgs
    {
        public CheckIn CheckIn { get; private set; }

        public CheckInEventArgs(CheckIn checkIn)
        {
            CheckIn = checkIn;
        }
    }
}
