using Domain;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ECommerceContext _eCommerceContext;

        public Repository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public async Task Add(T entity)
        {
            await _eCommerceContext.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await Get(id);
            _eCommerceContext.Set<T>().Remove(entity);
        }

        public virtual async Task<T> Get(int id)
        {
            return await _eCommerceContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _eCommerceContext.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            _eCommerceContext.Set<T>().Update(entity);
        }
    }
}
