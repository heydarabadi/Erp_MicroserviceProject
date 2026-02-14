using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Shared.Ui.Dependencies.Communication.ServiceCooordination;

public static class ServiceCoordinationDependencyInjection
{
    public static WebApplication RegisterConsul(this WebApplication app, 
        (string serviceName, string serviceId, string consulHostName) service)
    {
        var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(ServiceCoordinationDependencyInjection));
        var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

        var baseUrl = app.Urls.FirstOrDefault() ?? app.Configuration["ASPNETCORE_URLS"] ?? "http://localhost:5044/";
        var uri = new Uri(baseUrl);
        var host = uri.Host;
        var servicePort = uri.Port;

        // ایجاد کلاینت Consul
        using var consulClient = new ConsulClient(config =>
        {
            config.Address = new Uri(service.consulHostName);
        });

        var healthCheckUrl = $"{baseUrl.TrimEnd('/')}/agent/checks";
        
        var registration = new AgentServiceRegistration
        {
            ID = service.serviceId,
            Name = service.serviceName,
            Address = host,
            Port = servicePort
            // Check = new AgentServiceCheck
            // {
            //     Interval = TimeSpan.FromSeconds(2),
            //     Timeout = TimeSpan.FromSeconds(5),
            //     DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(30),
            //     HTTP = healthCheckUrl
            // }
        };

        try
        {
            consulClient.Agent.ServiceRegister(registration).GetAwaiter().GetResult();
            logger.LogInformation("Service '{ServiceName}' successfully registered with Consul", registration.Name);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to register service '{ServiceName}' in Consul", registration.Name);
            throw;
        }

        lifetime.ApplicationStopped.Register(() =>
        {
            try
            {
                consulClient.Agent.ServiceDeregister(service.serviceId).GetAwaiter().GetResult();
                logger.LogInformation("Service {ServiceName} successfully deregistered from Consul", service.serviceName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deregistering service {ServiceName} from Consul", service.serviceName);
            }
        });

        return app;
    }
}