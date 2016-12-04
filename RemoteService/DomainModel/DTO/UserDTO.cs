using System.Runtime.Serialization;

namespace DomainModel.DTO
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string Name { get; set; }
    }
}