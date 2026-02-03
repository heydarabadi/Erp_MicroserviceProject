using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseService.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addinventoryiteminit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageLocation_Warehouses_WarehouseId",
                table: "StorageLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StorageLocation",
                table: "StorageLocation");

            migrationBuilder.RenameTable(
                name: "StorageLocation",
                newName: "StorageLocations");

            migrationBuilder.RenameIndex(
                name: "IX_StorageLocation_WarehouseId",
                table: "StorageLocations",
                newName: "IX_StorageLocations_WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StorageLocations",
                table: "StorageLocations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SKU = table.Column<string>(type: "text", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    OnHandQuantity = table.Column<int>(type: "integer", nullable: false),
                    ReservedQuantity = table.Column<int>(type: "integer", nullable: false),
                    LastMovementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StorageLocations_Warehouses_WarehouseId",
                table: "StorageLocations",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageLocations_Warehouses_WarehouseId",
                table: "StorageLocations");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StorageLocations",
                table: "StorageLocations");

            migrationBuilder.RenameTable(
                name: "StorageLocations",
                newName: "StorageLocation");

            migrationBuilder.RenameIndex(
                name: "IX_StorageLocations_WarehouseId",
                table: "StorageLocation",
                newName: "IX_StorageLocation_WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StorageLocation",
                table: "StorageLocation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageLocation_Warehouses_WarehouseId",
                table: "StorageLocation",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
