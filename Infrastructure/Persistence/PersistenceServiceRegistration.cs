using System.Reflection;
using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Services;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrdersService, OrdersService>();
            // services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IProductsService, ProductsService>();

            var contextAssembly = typeof(DataContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContextPool<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(nameof(DataContext)),
                    b => b.MigrationsAssembly(contextAssembly));
                // options.UseInMemoryDatabase(databaseName: nameof(DataContext));
            });

            return services;    
        }
    }
}