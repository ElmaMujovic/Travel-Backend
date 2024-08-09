using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Migrations
{
    public partial class AddPaketModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Paketi");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Paketi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Paketi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Paketi");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Paketi");

            migrationBuilder.AddColumn<decimal>(
                name: "Cena",
                table: "Paketi",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
