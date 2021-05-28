using DataAccess;
using Domain;
using Domain.CustomerAggregate;
using Domain.OrderAggregate;
using Domain.OrderProductAggregate;
using Domain.ProductAggregate;
using Domain.ProductMetaDataAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI
{
    public static class RegisterServices
    {
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceContext>(options =>
                options.UseInMemoryDatabase(databaseName: "ECommerceContext")
            );

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductMetaDataRepository, ProductMetaDataRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderProductRepository, OrderProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
