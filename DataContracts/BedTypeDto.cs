using System.Runtime.Serialization;

namespace DomainModel.DataContracts
{
    [DataContract]
    public class BedTypeDto
    {
        [DataMember]
        public string Name { get; set; }
    }
}