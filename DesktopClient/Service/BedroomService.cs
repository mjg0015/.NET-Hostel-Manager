using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IBedroomService
    {
        List<Bedroom> GetAll();

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
        public bool CreateOrUpdate(Bedroom bedroom)
        {
            throw new NotImplementedException();
        }

        public List<Bedroom> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Bedroom> GetFiltered(int minSize, double maxPrice, BathroomType bathroomType, BedType bedType, bool available)
        {
            throw new NotImplementedException();
        }
    }
}
