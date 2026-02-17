using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace Share.Communication.GrpcFramework.Framework.Interceptors;

public class LoggingInterceptor : Interceptor
{
    private readonly ILogger<LoggingInterceptor> _logger;

    public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> UnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        where TRequest : class
        where TResponse : class
    {
        _logger.LogInformation("gRPC call started: {Method}", context.Method);

        try
        {
            var response = await continuation(request, context);
            _logger.LogInformation("gRPC call succeeded: {Method}", context.Method);
            return response;
        }
        catch (RpcException ex)
        {
            _logger.LogError(ex, "gRPC call failed: {Method} - Status: {Status}", context.Method, ex.Status);
            throw;
        }
    }
}