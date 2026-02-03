using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;
using WarehouseService.Api.Infrastructure.ApplicationOptions;

namespace WarehouseService.Api.Infrastructure.Db.PostgresSql.DatabaseContexts;

public sealed class WarehouseDbContext:DbContext
{
    private readonly IOptions<WarehouseOption> _warehouseOption;
    public WarehouseDbContext(DbContextOptions options, IOptions<WarehouseOption> wareOptions) : base(options)
    {
        _warehouseOption = wareOptions;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.
           ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);
    }
    
    

    #region Db Sets
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<StorageLocation> StorageLocations { get; set; }
    #endregion
    
    
    
    
    
}