using Domain.ProductMetaDataAggregate;

namespace DataAccess
{
    public class ProductMetaDataRepository : Repository<ProductMetaData>, IProductMetaDataRepository
    {
        public ProductMetaDataRepository(ECommerceContext context) : base(context){}
    }
}
