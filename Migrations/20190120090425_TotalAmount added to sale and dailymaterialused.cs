using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class TotalAmountaddedtosaleanddailymaterialused : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Sales",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "DailyMaterialsUsed",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "DailyMaterialsUsed");
        }
    }
}
