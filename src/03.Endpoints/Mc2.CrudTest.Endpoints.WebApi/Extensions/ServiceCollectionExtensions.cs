using Mc2.CrudTest.Application.Extensions;
using Mc2.CrudTest.Domain.Extensions;
using Mc2.CrudTest.Persistence.EntityFramework.Extensions;
using Microsoft.AspNetCore.Hosting;


namespace Mc2.CrudTest.Endpoints.WebApi.Extensions;
internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlServerQueryConnectionString = configuration.GetConnectionString("SqlServerConnectionString");
        services.AddPersistenceEntityFrameworkServices(sqlServerQueryConnectionString);
        services.AddDomainServices();
        services.AddApplicationServices();
        services.AddEndpointsApiExplorer();

        return services;
    }
}