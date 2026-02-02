using Microsoft.EntityFrameworkCore;

namespace Warehouse.Api.Infrastructure.SqlServer;

public class WarehouseDbContext:DbContext
{
    public WarehouseDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    
    
    
    #region DbSet
    
    
    #endregion
    
    
}