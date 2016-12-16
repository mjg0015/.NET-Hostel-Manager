using System;
using System.Collections.Generic;
using DomainModel.DataContracts;

namespace DesktopClient.Adapters
{
    public class CheckInDtoAdapter
    {
        
        public string Id { get; set; }

        public DateTime ArrivingDate { get; set; }

        public DateTime DepartureDate { get; set; }
      
        public IList<GuestDto> Guests { get; set; }

        public BedroomDtoAdapter Bedroom { get; set; }

        public bool Active { get; set; }

        public double Price { get; set; }

        public CheckInDtoAdapter()
        {
            
        }

        public CheckInDtoAdapter(CheckInDto checkIn)
        {
            Id = checkIn.Id;
            ArrivingDate = checkIn.ArrivingDate;
            DepartureDate = checkIn.DepartureDate;
            Guests = checkIn.Guests;
            Bedroom = new BedroomDtoAdapter(checkIn.Bedroom);
            Active = checkIn.Active;
            Price = checkIn.Price;
        }

        public CheckInDto ToCheckInDto()
        {
            CheckInDto checkIn = new CheckInDto();
            checkIn.Id = Id;
            checkIn.ArrivingDate = ArrivingDate;
            checkIn.DepartureDate = DepartureDate;
            checkIn.Guests = Guests;
            checkIn.Bedroom = Bedroom.ToBedroomDto();
            checkIn.Active = Active;
            checkIn.Price = Price;
            return checkIn;
        }

        public override string ToString()
        {
            return Bedroom.ToString();
        }
    }
}
