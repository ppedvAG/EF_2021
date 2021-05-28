using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore_CodeFirstFromDatabase.Migrations
{
    public partial class Ohre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnzahlOhren",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnzahlOhren",
                table: "Customers");
        }
    }
}
