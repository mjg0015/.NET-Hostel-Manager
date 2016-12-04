using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<E>
    {
        Task<IList<E>> FindAllAsync();

        Task<bool> InsertAsync(E entity);
    }

    public abstract class Repository<E> : IRepository<E>
    {
        protected IMongoCollection<E> _collection;

        public Repository(IMongoDatabase db, string collectionName)
        {
            _collection = db.GetCollection<E>(collectionName);
        }

        public async Task<IList<E>> FindAllAsync()
        {
            IList<E> entities = await _collection.Find(_ => true).ToListAsync();
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
