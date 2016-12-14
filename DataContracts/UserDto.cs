using System.Runtime.Serialization;

namespace DomainModel.DataContracts
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string Name { get; set; }
    }
}