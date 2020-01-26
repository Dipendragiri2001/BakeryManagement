using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class assdssdssdadsdads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProfitOrLoss",
                table: "ProfitLosses",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProfitOrLoss",
                table: "ProfitLosses",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
