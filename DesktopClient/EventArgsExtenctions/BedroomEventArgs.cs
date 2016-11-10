using System;
using DesktopClient.Model;

namespace DesktopClient.EventArgsExtenctions
{
    public class BedroomEventArgs:EventArgs
    {
        public Bedroom Bedroom { get; private set; }

        public BedroomEventArgs(Bedroom bedroom)
        {
            Bedroom = bedroom;
        }
    }
}
