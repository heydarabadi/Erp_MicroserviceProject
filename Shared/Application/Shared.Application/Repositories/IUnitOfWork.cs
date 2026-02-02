namespace Shared.Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    // متد اصلی برای ذخیره تغییرات
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    // مدیریت تراکنش‌ها برای کنترل دقیق‌تر در لایه Application
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

    // بررسی اینکه آیا در حال حاضر تراکنشی فعال است یا خیر
    bool HasActiveTransaction { get; }
}