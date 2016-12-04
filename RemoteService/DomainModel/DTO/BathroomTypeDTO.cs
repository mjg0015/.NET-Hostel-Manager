using System.Runtime.Serialization;

namespace DomainModel.DTO
{
    [DataContract]
    public class BathroomTypeDTO
    {
        [DataMember]
        public string Name { get; set; }
    }
}