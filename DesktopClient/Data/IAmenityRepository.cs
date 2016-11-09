using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Data
{
    public interface IAmenityRepository<E> : IRepository<E>
    {
        Task<E> FindByTypeAsync(string type);
    }
}
