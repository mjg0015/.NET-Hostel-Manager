using System;
using System.Runtime.Serialization;

namespace DomainModel.DTO
{
    [DataContract]
    public class GuestDTO
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