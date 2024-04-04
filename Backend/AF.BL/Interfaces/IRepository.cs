using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.BL.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int entityId);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(int entityId);

    }
}
