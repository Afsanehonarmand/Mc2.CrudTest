using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Domain.Extensions
{
    public static class DomainServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ICheckDuplicateCustomerEmailService, CheckDuplicateCustomerEmailService>();
            services.AddTransient<ICheckDuplicateInformationService, CheckDuplicateInformationService>();
        }
    }
}
