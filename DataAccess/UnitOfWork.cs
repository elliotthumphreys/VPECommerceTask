using Domain;
using Domain.CustomerAggregate;
using Domain.OrderAggregate;
using Domain.OrderProductAggregate;
using Domain.ProductAggregate;
using Domain.ProductMetaDataAggregate;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private ECommerceContext _eCommerceContext {get;}
        public IProductRepository Product { get; }
        public IProductMetaDataRepository ProductMetaData { get; }
        public IOrderRepository Order { get; }
        public IOrderProductRepository OrderProduct { get; }
        public ICustomerRepository Customer { get; }

        public UnitOfWork(ECommerceContext eCommerceContext,
            IProductRepository product,
            IProductMetaDataRepository productMetaData,
            IOrderRepository order,
            IOrderProductRepository orderProduct,
            ICustomerRepository customer)
        {
            _eCommerceContext = eCommerceContext;
            Product = product;
            ProductMetaData = productMetaData;
            Order = order;
            OrderProduct = orderProduct;
            Customer = customer;
        }

        public Task<int> CommitChanges()
        {
            return _eCommerceContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _eCommerceContext.Dispose();
            }
        }
    }
}
