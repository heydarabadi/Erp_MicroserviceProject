using Microsoft.AspNetCore.Http;

namespace Shared.Ui;
public class ResponseWrapperMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseWrapperMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await _next(context);

        context.Response.Body = originalBodyStream;

        // فقط اگر پاسخ موفق بود و هنوز Wrap نشده بود
        if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
        {
            responseBody.Seek(0, SeekOrigin.Begin);
            var content = await new StreamReader(responseBody).ReadToEndAsync();

            // ساخت شیء پاسخ موفق
            // محتوا را مستقیم به عنوان یک "رشته" یا "شیء خام" می‌فرستیم تا نیازی به Deserialize نباشد
            var wrappedResponse = new 
            {
                IsSuccess = true,
                Data = TryDeserialize(content), // سعی می‌کند اگر JSON است آن را بشکند، وگرنه خود متن را برمی‌گرداند
                Message = "عملیات با موفقیت انجام شد.",
                Code = (string?)null
            };

            await context.Response.WriteAsJsonAsync(wrappedResponse);
        }
        else
        {
            // اگر خطا بود (توسط ExceptionHandler مدیریت شده)، همان را کپی کن
            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }

    private object? TryDeserialize(string content)
    {
        if (string.IsNullOrWhiteSpace(content)) return null;
        
        try
        {
            // تلاش برای تشخیص اینکه آیا محتوا خودش یک JSON است یا فقط یک متن ساده
            using var jsonDoc = System.Text.Json.JsonDocument.Parse(content);
            return jsonDoc.RootElement.Clone(); // اگر JSON معتبر بود
        }
        catch
        {
            return content; // اگر متن ساده یا HTML بود، همان را برگردان
        }
    }
}