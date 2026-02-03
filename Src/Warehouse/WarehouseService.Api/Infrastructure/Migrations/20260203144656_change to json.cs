using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseService.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changetojson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Address",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Location_Latitude",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Location_Longitude",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Address_Bin",
                table: "StorageLocation");

            migrationBuilder.DropColumn(
                name: "Address_Shelf",
                table: "StorageLocation");

            migrationBuilder.DropColumn(
                name: "Address_Zone",
                table: "StorageLocation");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Warehouses",
                type: "jsonb",
                nullable: false,
                defaultValue: "{}");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "StorageLocation",
                type: "jsonb",
                nullable: false,
                defaultValue: "{}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "StorageLocation");

            migrationBuilder.AddColumn<string>(
                name: "Location_Address",
                table: "Warehouses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Location_Latitude",
                table: "Warehouses",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Location_Longitude",
                table: "Warehouses",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Address_Bin",
                table: "StorageLocation",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Shelf",
                table: "StorageLocation",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Zone",
                table: "StorageLocation",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
