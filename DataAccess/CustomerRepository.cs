using Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ECommerceContext context) : base(context){}

        public override Task<Customer> Get(int id)
        {
            return _eCommerceContext
                .Set<Customer>()
                .Include(_ => _.Orders)
                .FirstAsync(_ => _.CustomerId == id);
        }
    }
}
