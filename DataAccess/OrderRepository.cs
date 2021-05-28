using Domain.OrderAggregate;

namespace DataAccess
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceContext context) : base(context){}
    }
}
