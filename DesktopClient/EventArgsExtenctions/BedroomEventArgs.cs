using System;
using DesktopClient.Model;

namespace DesktopClient.EventArgsExtenctions
{
    class BedroomEventArgs:EventArgs
    {
        public Bedroom Bedroom { get; private set; }

        public BedroomEventArgs(Bedroom bedroom)
        {
            Bedroom = bedroom;
        }
    }
}
