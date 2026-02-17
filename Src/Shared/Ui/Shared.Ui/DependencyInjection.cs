using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Shared.Application.DependencyInjections;
using Shared.Ui.Dependencies.Communication.ServiceCooordination;

namespace Shared.Ui;

public static class DependencyInjection
{
    public static IServiceCollection AddUiSharedBuildServices(this IServiceCollection services,
        params Assembly[] assemblies)
    {
        services.AddOpenApi();
        
        // Exception Middleware Handling
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        
        // Fluent Validation
        services.AddFluentValidationAutoValidation();
        foreach (var assembly in assemblies)
        {
            services.AddValidatorsFromAssembly(assembly);
        }
        
        // Endpoint Discovery
        var endpointDefinitions = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => typeof(IEndpointDefinition).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var endpointDefinition in endpointDefinitions)
        {
            services.AddSingleton(typeof(IEndpointDefinition), endpointDefinition);
        }
        
        // Scalar
        services.AddEndpointsApiExplorer();


        #region CQRS

        services.AddCqrs(assemblies);

        #endregion
        
        return services;
    }
    
    public static WebApplication UseUiSharedBuildServices(this WebApplication app
        ,IConfiguration configuration, bool enableHttpRedirection=false)
    {
        string findServiceName = configuration.GetSection("Consul")
            .GetSection("ServiceName")?.Value!;
        
        app.MapOpenApi();
        
        app.UseMiddleware<ResponseWrapperMiddleware>();
        
        app.UseExceptionHandler();

        var definitions = app.Services.GetServices<IEndpointDefinition>();

        foreach (var definition in definitions)
        {
            definition.DefineEndpoints(app);
        }
        
        app.MapScalarApiReference(options => 
        {   
            options
                .WithTitle(findServiceName)
                .WithTheme(ScalarTheme.Moon)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });


        #region Service Cooordination
    
       
        string findServiceId = configuration.GetSection("Consul")
            .GetSection("ServiceId")?.Value!;

        string findConsulHostName = configuration.GetSection("Consul")
            .GetSection("HostName")?.Value!;
        
        // Service Coordination
        // Register
        app.RegisterConsul((findServiceName,
            findServiceId,findConsulHostName));

        #endregion

      
        
        if(enableHttpRedirection)
            app.UseHttpsRedirection();

        return app;
    }
}