using EfCodeFirst.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EfCodeFirst.Migrations
{
    public partial class GehaltWiederAlsDecZusatz : Migration
    { 
  
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GehaltAlsDec",
                table: "Mitarbeiter",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            
            //using (var con = new EfContext())
            //{
            //    foreach (var m in con.Mitarbeiter)
            //    {
            //        if (decimal.TryParse(m.Gehalt, out var res))
            //            m.GehaltAlsDec = res;
            //    }
            //}
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GehaltAlsDec",
                table: "Mitarbeiter");
        }
    }
}
