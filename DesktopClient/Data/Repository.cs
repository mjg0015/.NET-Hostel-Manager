using Domain.Service;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public interface IRepository<E>
    {
        List<E> FindAll();

        bool InsertOrUpdate(E entity);
    }

    public abstract class Repository<E> : IRepository<E>
    {
        protected IMongoCollection<E> _collection;

        public Repository(string collectionName)
        {
            var db = PersistenceService.GetDatabase();
            _collection = db.GetCollection<E>(collectionName);
        }

        public List<E> FindAll()
        {
            List<E> entities = _collection.Find(_ => true).ToList();
            return entities;
        }

        public bool InsertOrUpdate(E entity)
        {
            try
            {
                _collection.InsertOne(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
