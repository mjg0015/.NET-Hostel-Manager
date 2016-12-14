using System;
using System.Runtime.Serialization;

namespace DomainModel.DataContracts
{
    [DataContract]
    public enum Sex
    {
        [EnumMember]
        MALE,
        [EnumMember]
        FEMALE
    }

    [DataContract]
    public class GuestDto
    {
        [DataMember]
        public string DocumentId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public DateTime BirthDate { get; set; }

        [DataMember]
        public Sex Sex { get; set; }
    }
}