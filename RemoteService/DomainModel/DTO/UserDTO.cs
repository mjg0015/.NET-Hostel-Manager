using System.Runtime.Serialization;

namespace DomainModel.DTO
{
    [DataContract(Name = "UserDTO")]
    public class UserDTO
    {
        [DataMember]
        public string Name { get; set; }
    }
}