using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCodeFirst.Migrations
{
    public partial class HomeOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HomeOffice",
                table: "Mitarbeiter",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Sitzplatz",
                table: "Mitarbeiter",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeOffice",
                table: "Mitarbeiter");

            migrationBuilder.DropColumn(
                name: "Sitzplatz",
                table: "Mitarbeiter");
        }
    }
}
