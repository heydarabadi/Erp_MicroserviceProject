using Consul;
using Microsoft.Extensions.Configuration;

namespace Share.Communication.ServiceCoordination.ServiceDiscovery.Concretes;

public class ConsulServiceDiscovery:IServiceDiscovery
{
    private ConsulClient _consulClient { get; set; }
    public ConsulServiceDiscovery(IConfiguration configuration)
    {
        var consulHostName = configuration.GetSection("Consul")
            .GetSection("HostName").Value;
        
        _consulClient = new ConsulClient(x =>
            x.Address = new Uri(consulHostName));
    }
    public async Task<Uri> GetServiceUrl(string serviceName)
    {
        var services = await _consulClient.Agent.Services();
        var catalogServices = services.Response.Values.FirstOrDefault(x => x.ID == serviceName);
        
        ArgumentNullException.ThrowIfNull(catalogServices);
        
        string uri = "http://" + catalogServices.Address + ":" + catalogServices.Port;
        
        Uri resultUri = new Uri(uri);
        return resultUri;    
    }
}