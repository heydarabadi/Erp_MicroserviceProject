namespace Shared.Ui;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public string? Code { get; set; }

    // متدهای کمکی برای کست کردن راحت‌تر
    public static ApiResponse<T> Success(T data, string? message = null) 
        => new() { IsSuccess = true, Data = data, Message = message };

    public static ApiResponse<object> Failure(string message, string code) 
        => new() { IsSuccess = false, Message = message, Code = code };
}