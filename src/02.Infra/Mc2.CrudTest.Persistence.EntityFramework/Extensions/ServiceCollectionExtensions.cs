using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Persistence.EntityFramework.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Persistence.EntityFramework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceEntityFrameworkServices(this IServiceCollection services, string sqlServerConnectionString)
        {
            services.AddDbContext<Mc2CrudTestDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(sqlServerConnectionString,
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
            });
            services.AddScoped<DbContext>((sp) => sp.GetRequiredService<Mc2CrudTestDbContext>());
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
