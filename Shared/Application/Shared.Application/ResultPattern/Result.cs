namespace Shared.Application.ResultPattern;

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, string.Empty);
    public static Result Failure(string error) => new(false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public TValue Value => IsSuccess 
        ? _value! 
        : throw new InvalidOperationException("نمی‌توان به مقدار یک نتیجه شکست‌خورده دسترسی داشت.");

    protected internal Result(TValue? value, bool isSuccess, string error) 
        : base(isSuccess, error)
    {
        _value = value;
    }

    // این دو متد بسیار مهم هستند:
    public static Result<TValue> Success(TValue value) => new(value, true, string.Empty);
    public new static Result<TValue> Failure(string error) => new(default, false, error);
}