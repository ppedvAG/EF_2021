using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCodeFirst.Migrations
{
    public partial class Gehalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Gehalt",
                table: "Mitarbeiter",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gehalt",
                table: "Mitarbeiter");
        }
    }
}
