using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class assdssdssdad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProfitOrLoss",
                table: "ProfitLosses",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProfitOrLoss",
                table: "ProfitLosses",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
