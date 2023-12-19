using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsBankWebApiTutorial.Migrations
{
    public partial class supplierTableAddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactTitle",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ContactTitle",
                table: "Suppliers");
        }
    }
}
