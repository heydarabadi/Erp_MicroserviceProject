using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

namespace WarehouseService.Api.Infrastructure.Db.PostgresSql.EntityConfigurations;

public class StorageLocationConfiguration:IEntityTypeConfiguration<StorageLocation>
{
    public void Configure(EntityTypeBuilder<StorageLocation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ComplexProperty(x => x.Address, add =>
        {
            add.ToJson();
        });        
        builder.HasOne(x=>x.Warehouse)
            .WithMany(x=>x.StorageLocations)
            .HasForeignKey(x=>x.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
    }
}