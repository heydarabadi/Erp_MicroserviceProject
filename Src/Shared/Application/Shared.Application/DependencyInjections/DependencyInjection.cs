using System.Reflection;
using DispatchR.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.CqrsConfig;
using Shared.Application.CqrsConfig.Contracts;

namespace Shared.Application.DependencyInjections;

public static class DependencyInjection
{
    public static IServiceCollection AddCqrs(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddScoped<IMediator, Mediator>();
        foreach (var assembly in assemblies)
        {
            services.AddDispatchR(assembly);
        }

        return services;
    }
}