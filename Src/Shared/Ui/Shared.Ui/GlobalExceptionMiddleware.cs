using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.Domain;

namespace Shared.Ui;
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Error: {Message}", exception.Message);

        var (statusCode, errorCode) = exception switch
        {
            DomainException dex => (StatusCodes.Status400BadRequest, dex.Code),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized"),
            _ => (StatusCodes.Status500InternalServerError, "InternalServerError")
        };

        httpContext.Response.StatusCode = statusCode;

        var response = ApiResponse<object>.Failure(
            statusCode == 500 ? "خطای داخلی سرور" : exception.Message, 
            errorCode
        );

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}