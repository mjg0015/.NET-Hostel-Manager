using Domain.Model;
using Domain.Service;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Data
{
    public interface IBedroomRepository : IRepository<Bedroom>
    {
        List<Bedroom> FindAvailable();

        bool Remove(Bedroom bedroom);
    }

    public class BedroomRepository : Repository<Bedroom>, IBedroomRepository
    {

        public BedroomRepository() : base("bedrooms")
        {
        }

        public List<Bedroom> FindAvailable()
        {
            List<Bedroom> bedrooms = _collection.Find(x => x.Available == true).ToList();
            return bedrooms;
        }

        public bool Remove(Bedroom bedroom)
        {
            var deletedCount = _collection.DeleteOne(x => x.Number == bedroom.Number).DeletedCount;
            if(deletedCount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
