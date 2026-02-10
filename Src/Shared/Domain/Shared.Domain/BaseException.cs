namespace Shared.Domain;

public abstract class BaseException : Exception
{
    public string Code { get; init; }
    
    public string? Details { get; init; }

    protected BaseException(string message, string code, string? details = null) 
        : base(message)
    {
        Code = code;
        Details = details;
    }

    protected BaseException(string message) 
        : base(message)
    {
        Code = "Error";
    }
}