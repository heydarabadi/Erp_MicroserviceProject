using Share.Common;

namespace Share.Communication.ServiceCoordination.ServiceDiscovery;

public interface IServiceDiscovery
{
    Task<Uri> GetServiceUrl(ServiceNamesEnum serviceName);
}