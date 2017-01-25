using System.Runtime.Serialization;

namespace DomainModel.DataContracts
{
    [DataContract]
    public enum Role
    {
        [EnumMember]
        MANAGER,
        [EnumMember]
        USER
    }

    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Role Role { get; set; }
    }
}