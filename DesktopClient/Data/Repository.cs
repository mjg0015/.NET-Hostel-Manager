using System;
using System.Collections.Generic;
using DesktopClient.Service;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public interface IRepository<E>
    {
        Task<List<E>> FindAllAsync();

        Task<bool> InsertAsync(E entity);
    }

    public abstract class Repository<E> : IRepository<E>
    {
        protected IMongoCollection<E> _collection;

        public Repository(string collectionName)
        {
            var db = PersistenceFactory.GetDatabase();
            _collection = db.GetCollection<E>(collectionName);
        }

        public async Task<List<E>> FindAllAsync()
        {
            List<E> entities = await _collection.Find(_ => true).ToListAsync();
            return entities;
        }

        public async Task<bool> InsertAsync(E entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
