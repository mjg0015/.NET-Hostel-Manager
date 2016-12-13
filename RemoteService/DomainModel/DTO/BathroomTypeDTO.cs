using System.Runtime.Serialization;

namespace DomainModel.DTO
{
    [DataContract(Name = "BathroomTypeDTO")]
    public class BathroomTypeDTO
    {
        [DataMember]
        public string Name { get; set; }
    }
}