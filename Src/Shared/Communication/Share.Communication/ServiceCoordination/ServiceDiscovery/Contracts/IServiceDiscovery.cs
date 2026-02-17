using Share.Common;

namespace Share.Communication.ServiceCoordination.ServiceDiscovery.Contracts;

public interface IServiceDiscovery
{
    Task<Uri> GetServiceUrl(ServiceNamesEnum serviceName);
}