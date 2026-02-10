using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Shared.Ui;

public class ResponseWrapperMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseWrapperMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        if (context.Request.Path.StartsWithSegments("/scalar") ||
            context.Request.Path == "/" ||
            context.Request.Path.StartsWithSegments("/openapi") ||
            !string.IsNullOrEmpty(context.Response.ContentType) &&
            !context.Response.ContentType.Contains("application/json", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }
        
        var originalBody = context.Response.Body;
        
        bool shouldWrap =
            context.Request.Method != HttpMethods.Options &&
            context.Request.Method != HttpMethods.Head &&
            context.Response.ContentType?.Contains("application/json", StringComparison.OrdinalIgnoreCase) == true ||
            context.Response.ContentType is null;  

        if (!shouldWrap)
        {
            await _next(context);
            return;
        }

        await using var responseBody = new MemoryStream(8192); 
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            context.Response.Body = originalBody;
            
            if (responseBody.Length == 0)
            {
                if (context.Response.StatusCode == StatusCodes.Status204NoContent)
                {

                    return;
                }


            }

            responseBody.Seek(0, SeekOrigin.Begin);

            if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
            {
                string content = await new StreamReader(responseBody).ReadToEndAsync();

                object? data = TryParseContent(content);

                var wrapped = new
                {
                    IsSuccess = true,
                    Data = data,
                    Message = "Success",
                    Code = (string?)null
                };

                
                context.Response.Headers.Remove("Content-Length");

                context.Response.ContentType = "application/json; charset=utf-8";

                await context.Response.WriteAsJsonAsync(wrapped, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = false,
                });
            }
            else
            {
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBody);
            }
        }
        catch (Exception ex)
        {
            context.Response.Body = originalBody;
            throw;
        }
    }

    private static object? TryParseContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return null;

        try
        {
            using var doc = JsonDocument.Parse(content);
            return doc.RootElement.Clone(); 
        }
        catch (JsonException)
        {

            try
            {
                return JsonNode.Parse(content)?.DeepClone();
            }
            catch
            {
                return content;
            }
        }
    }
}