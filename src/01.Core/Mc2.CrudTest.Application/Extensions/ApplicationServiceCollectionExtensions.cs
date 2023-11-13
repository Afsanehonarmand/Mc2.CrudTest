using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using System.Net.NetworkInformation;

namespace Mc2.CrudTest.Application.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
      cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceCollectionExtensions).Assembly));
    }
}