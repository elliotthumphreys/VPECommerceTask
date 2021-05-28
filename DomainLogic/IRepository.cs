using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        Task Add(T entity);
        Task Delete(int id);
        void Update(T entity);
    }
}
