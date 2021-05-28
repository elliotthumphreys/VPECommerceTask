using Domain.OrderProductAggregate;

namespace DataAccess
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(ECommerceContext context) : base(context){}
    }
}
