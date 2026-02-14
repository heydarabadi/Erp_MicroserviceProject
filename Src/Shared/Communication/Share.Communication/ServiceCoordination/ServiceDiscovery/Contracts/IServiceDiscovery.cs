namespace Share.Communication.ServiceCoordination.ServiceDiscovery;

public interface IServiceDiscovery
{
    Task<Uri> GetServiceUrl(string serviceName);
}