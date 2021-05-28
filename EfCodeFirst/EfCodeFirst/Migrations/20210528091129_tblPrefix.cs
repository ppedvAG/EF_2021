using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCodeFirst.Migrations
{
    public partial class tblPrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbteilungMitarbeiter_Abteilungen_AbteilungenId",
                table: "AbteilungMitarbeiter");

            migrationBuilder.DropForeignKey(
                name: "FK_AbteilungMitarbeiter_Mitarbeiter_MitarbeiterId",
                table: "AbteilungMitarbeiter");

            migrationBuilder.DropForeignKey(
                name: "FK_Kunde_Mitarbeiter_MitarbeiterId",
                table: "Kunde");

            migrationBuilder.DropForeignKey(
                name: "FK_Kunde_Person_Id",
                table: "Kunde");

            migrationBuilder.DropForeignKey(
                name: "FK_Mitarbeiter_Person_Id",
                table: "Mitarbeiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mitarbeiter",
                table: "Mitarbeiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kunde",
                table: "Kunde");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbteilungMitarbeiter",
                table: "AbteilungMitarbeiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abteilungen",
                table: "Abteilungen");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "tbl_Person");

            migrationBuilder.RenameTable(
                name: "Mitarbeiter",
                newName: "tbl_Mitarbeiter");

            migrationBuilder.RenameTable(
                name: "Kunde",
                newName: "tbl_Kunde");

            migrationBuilder.RenameTable(
                name: "AbteilungMitarbeiter",
                newName: "tbl_AbteilungMitarbeiter");

            migrationBuilder.RenameTable(
                name: "Abteilungen",
                newName: "tbl_Abteilungen");

            migrationBuilder.RenameIndex(
                name: "IX_Kunde_MitarbeiterId",
                table: "tbl_Kunde",
                newName: "IX_tbl_Kunde_MitarbeiterId");

            migrationBuilder.RenameIndex(
                name: "IX_AbteilungMitarbeiter_MitarbeiterId",
                table: "tbl_AbteilungMitarbeiter",
                newName: "IX_tbl_AbteilungMitarbeiter_MitarbeiterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Person",
                table: "tbl_Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Mitarbeiter",
                table: "tbl_Mitarbeiter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Kunde",
                table: "tbl_Kunde",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_AbteilungMitarbeiter",
                table: "tbl_AbteilungMitarbeiter",
                columns: new[] { "AbteilungenId", "MitarbeiterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Abteilungen",
                table: "tbl_Abteilungen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_AbteilungMitarbeiter_tbl_Abteilungen_AbteilungenId",
                table: "tbl_AbteilungMitarbeiter",
                column: "AbteilungenId",
                principalTable: "tbl_Abteilungen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_AbteilungMitarbeiter_tbl_Mitarbeiter_MitarbeiterId",
                table: "tbl_AbteilungMitarbeiter",
                column: "MitarbeiterId",
                principalTable: "tbl_Mitarbeiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Kunde_tbl_Mitarbeiter_MitarbeiterId",
                table: "tbl_Kunde",
                column: "MitarbeiterId",
                principalTable: "tbl_Mitarbeiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Kunde_tbl_Person_Id",
                table: "tbl_Kunde",
                column: "Id",
                principalTable: "tbl_Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Mitarbeiter_tbl_Person_Id",
                table: "tbl_Mitarbeiter",
                column: "Id",
                principalTable: "tbl_Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_AbteilungMitarbeiter_tbl_Abteilungen_AbteilungenId",
                table: "tbl_AbteilungMitarbeiter");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_AbteilungMitarbeiter_tbl_Mitarbeiter_MitarbeiterId",
                table: "tbl_AbteilungMitarbeiter");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Kunde_tbl_Mitarbeiter_MitarbeiterId",
                table: "tbl_Kunde");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Kunde_tbl_Person_Id",
                table: "tbl_Kunde");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Mitarbeiter_tbl_Person_Id",
                table: "tbl_Mitarbeiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Person",
                table: "tbl_Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Mitarbeiter",
                table: "tbl_Mitarbeiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Kunde",
                table: "tbl_Kunde");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_AbteilungMitarbeiter",
                table: "tbl_AbteilungMitarbeiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Abteilungen",
                table: "tbl_Abteilungen");

            migrationBuilder.RenameTable(
                name: "tbl_Person",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "tbl_Mitarbeiter",
                newName: "Mitarbeiter");

            migrationBuilder.RenameTable(
                name: "tbl_Kunde",
                newName: "Kunde");

            migrationBuilder.RenameTable(
                name: "tbl_AbteilungMitarbeiter",
                newName: "AbteilungMitarbeiter");

            migrationBuilder.RenameTable(
                name: "tbl_Abteilungen",
                newName: "Abteilungen");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Kunde_MitarbeiterId",
                table: "Kunde",
                newName: "IX_Kunde_MitarbeiterId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_AbteilungMitarbeiter_MitarbeiterId",
                table: "AbteilungMitarbeiter",
                newName: "IX_AbteilungMitarbeiter_MitarbeiterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mitarbeiter",
                table: "Mitarbeiter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kunde",
                table: "Kunde",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbteilungMitarbeiter",
                table: "AbteilungMitarbeiter",
                columns: new[] { "AbteilungenId", "MitarbeiterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abteilungen",
                table: "Abteilungen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbteilungMitarbeiter_Abteilungen_AbteilungenId",
                table: "AbteilungMitarbeiter",
                column: "AbteilungenId",
                principalTable: "Abteilungen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbteilungMitarbeiter_Mitarbeiter_MitarbeiterId",
                table: "AbteilungMitarbeiter",
                column: "MitarbeiterId",
                principalTable: "Mitarbeiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kunde_Mitarbeiter_MitarbeiterId",
                table: "Kunde",
                column: "MitarbeiterId",
                principalTable: "Mitarbeiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kunde_Person_Id",
                table: "Kunde",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mitarbeiter_Person_Id",
                table: "Mitarbeiter",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
