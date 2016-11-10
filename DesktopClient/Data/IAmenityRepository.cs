using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public interface IAmenityRepository<E> : IRepository<E>
    {
        Task<E> FindByTypeAsync(string type);
    }
}
