using System.Runtime.Serialization;

namespace DomainModel.DTO
{
    [DataContract(Name = "BedTypeDTO")]
    public class BedTypeDTO
    {
        [DataMember]
        public string Name { get; set; }
    }
}