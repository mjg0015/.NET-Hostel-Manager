using System.Threading.Tasks;

namespace Data
{
    public interface IAmenityRepository<E> : IRepository<E>
    {
        Task<E> FindByTypeAsync(string type);
    }
}
