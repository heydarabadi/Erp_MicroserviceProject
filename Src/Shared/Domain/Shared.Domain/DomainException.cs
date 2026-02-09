namespace Shared.Domain;

public abstract class DomainException : Exception
{
    // کد یکتای خطا برای فرانت‌اند یا لاگ‌ها (مثلاً: "Order.InsufficientStock")
    public string Code { get; init; }
    
    // جزئیات اضافی برای عیب‌یابی
    public string? Details { get; init; }

    protected DomainException(string message, string code, string? details = null) 
        : base(message)
    {
        Code = code;
        Details = details;
    }

    protected DomainException(string message) 
        : base(message)
    {
        Code = "Error";
    }
}