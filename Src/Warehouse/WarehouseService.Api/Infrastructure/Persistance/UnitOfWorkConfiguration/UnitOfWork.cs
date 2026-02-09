using Microsoft.EntityFrameworkCore.Storage;
using Shared.Application.Repositories;
using Shared.Domain;
using WarehouseService.Api.Infrastructure.Db.PostgresSql.DatabaseContexts;

namespace WarehouseService.Api.Infrastructure.Persistance.UnitOfWorkConfiguration;

public class UnitOfWork:IUnitOfWork
{
    private readonly WarehouseDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(WarehouseDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task BeginTransactionAsync(CancellationToken ct = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(ct);
    }

    public async Task CommitTransactionAsync(CancellationToken ct = default)
    {
        if (_transaction is null) return;
        await _transaction.CommitAsync(ct);
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task RollbackTransactionAsync(CancellationToken ct = default)
    {
        if (_transaction is null) return;
        await _transaction.RollbackAsync(ct);
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }

    public bool HasActiveTransaction => _transaction != null;

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
    
    public void DisposeAsync(CancellationToken ce = default)
    {
        _transaction?.DisposeAsync();
        _context.DisposeAsync();
    }
}