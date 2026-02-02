using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using FluentValidation.AspNetCore;

namespace Shared.Ui;

public static class DependencyInjection
{
    public static IServiceCollection AddUiSharedBuildServices(this IServiceCollection services,
        params Assembly[] assemblies)
    {
        services.AddOpenApi();
        
        // Exception Middleware Handling
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails(); // برای سازگاری با استانداردهای مدرن
        
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
        
        
        
        return services;
    }
    
    public static WebApplication UseUiSharedBuildServices(this WebApplication app,string projectName)
    {
        app.MapOpenApi();
        
        app.UseMiddleware<ResponseWrapperMiddleware>();
        
        // فعال‌سازی سیستم مدیریت خطای سراسری
        app.UseExceptionHandler();

        var definitions = app.Services.GetServices<IEndpointDefinition>();

        foreach (var definition in definitions)
        {
            definition.DefineEndpoints(app);
        }
        
        app.MapScalarApiReference(options => 
        {   
            options
                .WithTitle(projectName)
                .WithTheme(ScalarTheme.Moon)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });
        
        return app;
    }
}