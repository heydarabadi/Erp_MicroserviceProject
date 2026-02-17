using Grpc.Core;
using Grpc.Net.ClientFactory;
using Microsoft.Extensions.DependencyInjection;
using Share.Common;
using Share.Communication.GrpcFramework.Framework.Interceptors;

namespace Share.Communication.GrpcFramework.Framework.Extentions;

public static class GrpcClientExtensions
{
    public static IServiceCollection AddGrpcTypedClient<TClient>(
        this IServiceCollection services, string serviceName,
        Action<GrpcClientFactoryOptions>? configure = null)
        where TClient : class
    {
        return services
            .AddGrpcClient<TClient>(options =>
            {
                options.Address = new Uri($"http://{serviceName}:5000");
            })
            .ConfigureChannel(channel =>
            {
                channel.Credentials = ChannelCredentials.Insecure;
            })
            .AddInterceptor<LoggingInterceptor>()
            // .AddInterceptor<TracingInterceptor>()
            // .AddInterceptor<AuthHeaderInterceptor>()
            // .AddInterceptor<RetryInterceptor>()
            .ConfigureHttpClient(http =>
            {
                http.Timeout = TimeSpan.FromSeconds(30);
            }).Services;

    }
}