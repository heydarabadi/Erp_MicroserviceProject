using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

namespace WarehouseService.Api.Infrastructure.Db.PostgresSql.EntityConfigurations;

public sealed class InventoryItemConfiguration :  IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.RowVersion).IsRowVersion();
        builder.Ignore(x=>x.AvailableQuantity);
        
        builder.HasQueryFilter(x=>x.IsDeleted==false);
    }
}