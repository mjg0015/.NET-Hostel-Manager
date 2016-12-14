using System.Runtime.Serialization;

namespace DomainModel.DataContracts
{
    [DataContract]
    public class BathroomTypeDto
    {
        [DataMember]
        public string Name { get; set; }
    }
}