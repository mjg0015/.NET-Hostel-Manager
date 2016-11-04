﻿using Domain.Data;
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
            throw new NotImplementedException();
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
