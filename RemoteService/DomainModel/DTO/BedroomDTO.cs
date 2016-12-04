using System.Runtime.Serialization;

namespace DomainModel.DTO
{
    [DataContract]
    public class BedroomDTO
    {
        [DataMember]
        public int Number { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int Size { get; set; }

        [DataMember]
        public bool Available { get; set; }

        [DataMember]
        public BathroomTypeDTO BathroomType { get; set; }

        [DataMember]
        public BedTypeDTO BedType { get; set; }
    }
}