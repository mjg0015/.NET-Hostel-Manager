using System;
using System.Collections.Generic;
using DesktopClient.Data;
using DesktopClient.Model;

namespace DesktopClient.Service
{
    public interface IBedroomService
    {
        List<Bedroom> GetAll();

        List<Bedroom> GetAvailable();

        List<Bedroom> GetFiltered(int minSize, double maxPrice, BathroomType bathroomType, BedType bedType, bool available);

        /// <summary>
        /// If bedroom exists, it will be updated with new configuration.
        /// Otherwise it will be created.
        /// </summary>
        /// <param name="bedroom">The bedroom</param>
        /// <returns></returns>
        bool CreateOrUpdate(Bedroom bedroom);
    }

    public class BedroomService : IBedroomService
    {
        private BedroomRepository _bedroomRepo;

        public BedroomService()
        {
            _bedroomRepo = new BedroomRepository();
        }

        public bool CreateOrUpdate(Bedroom bedroom)
        {
            return _bedroomRepo.InsertOrUpdate(bedroom);
        }

        public List<Bedroom> GetAll()
        {
            return _bedroomRepo.FindAll();
        }

        public List<Bedroom> GetAvailable()
        {
            return _bedroomRepo.FindAvailable();
        }

        public List<Bedroom> GetFiltered(int minSize, double maxPrice, BathroomType bathroomType, BedType bedType, bool available)
        {
            throw new NotImplementedException();
        }
    }
}
