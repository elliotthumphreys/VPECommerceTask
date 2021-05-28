using Domain.CustomerAggregate;
using Domain.OrderAggregate;
using Domain.OrderProductAggregate;
using Domain.ProductAggregate;
using Domain.ProductMetaDataAggregate;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        IProductMetaDataRepository ProductMetaData { get; }
        IOrderRepository Order { get; }
        IOrderProductRepository OrderProduct { get; }
        ICustomerRepository Customer { get; }

        Task<int> CommitChanges();
    }
}
