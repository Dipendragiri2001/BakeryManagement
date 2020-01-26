using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class sda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalMaterialUsedToday",
                table: "ProfitLosses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSaledToday",
                table: "ProfitLosses",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMaterialUsedToday",
                table: "ProfitLosses");

            migrationBuilder.DropColumn(
                name: "TotalSaledToday",
                table: "ProfitLosses");
        }
    }
}
