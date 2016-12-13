using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DomainModel.DTO
{
    [DataContract(Name = "CheckInDTO")]
    public class CheckInDTO
    {
        [DataMember]
        public object Id { get; set; }

        [DataMember]
        public DateTime ArrivingDate { get; set; }

        [DataMember]
        public DateTime DepartureDate { get; set; }

        [DataMember]
        public IList<GuestDTO> Guests { get; set; }

        [DataMember]
        public BedroomDTO Bedroom { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public double Price { get; set; }
    }
}