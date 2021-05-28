using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCodeFirst.Migrations
{
    public partial class EntityAndLastModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifier",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Abteilungen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifier",
                table: "Abteilungen",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LastModifier",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Abteilungen");

            migrationBuilder.DropColumn(
                name: "LastModifier",
                table: "Abteilungen");
        }
    }
}
