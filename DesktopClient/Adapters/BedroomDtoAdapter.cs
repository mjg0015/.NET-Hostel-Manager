using DomainModel.DataContracts;

namespace DesktopClient.Adapters
{
     public class BedroomDtoAdapter
    {
        public int Number { get; set; }

        public double Price { get; set; }

        public int Size { get; set; }
       
        public bool Available { get; set; }

        public BathroomTypeDto BathroomType { get; set; }

        public BedTypeDto BedType { get; set; }

         public BedroomDtoAdapter(BedroomDto bedroom)
         {
             Number = bedroom.Number;
             Price = bedroom.Price;
             Size = bedroom.Size;
             Available = bedroom.Available;
             BathroomType= bedroom.BathroomType;
             BedType = bedroom.BedType;
         }

         public override string ToString()
         {
             return "Number: " + Number + "; Size: " + Size + "; Price: " + Price;
         }

         public BedroomDto ToBedroomDto()
         {
             BedroomDto bedroomDto= new BedroomDto();
             bedroomDto.Number = Number;
             bedroomDto.Price = Price;
             bedroomDto.Size = Size;
             bedroomDto.Available = Available;
             bedroomDto.BathroomType.Name = BathroomType.Name;
             bedroomDto.BedType.Name = BedType.Name;
             return bedroomDto;
         }
    }
}

