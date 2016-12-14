using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DomainModel.DataContracts
{
    [DataContract]
    public class CheckInDto
    {
        [DataMember]
        public object Id { get; set; }

        [DataMember]
        public DateTime ArrivingDate { get; set; }

        [DataMember]
        public DateTime DepartureDate { get; set; }

        [DataMember]
        public IList<GuestDto> Guests { get; set; }

        [DataMember]
        public BedroomDto Bedroom { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public double Price { get; set; }
    }
}