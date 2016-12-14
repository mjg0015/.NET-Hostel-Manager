using System.Runtime.Serialization;

namespace DomainModel.DataContracts
{
    [DataContract]
    public class BedroomDto
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
        public BathroomTypeDto BathroomType { get; set; }

        [DataMember]
        public BedTypeDto BedType { get; set; }
    }
}