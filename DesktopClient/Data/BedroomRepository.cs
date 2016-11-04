using Domain.Model;
using Domain.Service;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Data
{
    public interface IBedroomRepository
    {
        List<Bedroom> FindAll();

        List<Bedroom> FindAvailable();
    }

    public class BedroomRepository : IBedroomRepository
    {
        private IMongoDatabase _db;
        
        public BedroomRepository()
        {
            _db = PersistenceService.GetDatabase();
        }

        public List<Bedroom> FindAll()
        {
            var collection = _db.GetCollection<Bedroom>("bedrooms");
            List<Bedroom> bedrooms = collection.Find(_ => true).ToList();

            return bedrooms;
        }

        public List<Bedroom> FindAvailable()
        {
            var collection = _db.GetCollection<Bedroom>("bedrooms");
            List<Bedroom> bedrooms = collection.Find(x => x.Available == true).ToList();
            return bedrooms;
        }
    }
}
