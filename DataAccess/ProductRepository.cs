using Domain.ProductAggregate;

namespace DataAccess
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceContext context) : base(context){}
    }
}
