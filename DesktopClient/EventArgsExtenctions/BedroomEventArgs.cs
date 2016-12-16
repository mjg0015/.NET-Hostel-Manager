using System;
using DomainModel.DataContracts;

namespace DesktopClient.EventArgsExtenctions
{
    public class BedroomEventArgs:EventArgs
    {
        public BedroomDto Bedroom { get; private set; }

        public BedroomEventArgs(BedroomDto bedroom)
        {
            Bedroom = bedroom;
        }
    }
}
