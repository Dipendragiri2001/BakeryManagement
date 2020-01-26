using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class assdssds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfitLosses_DailyMaterialsUsed_DailyMaterialUseId",
                table: "ProfitLosses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfitLosses_Products_ProductId",
                table: "ProfitLosses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfitLosses_Sales_SaleId",
                table: "ProfitLosses");

            migrationBuilder.DropIndex(
                name: "IX_ProfitLosses_DailyMaterialUseId",
                table: "ProfitLosses");

            migrationBuilder.DropIndex(
                name: "IX_ProfitLosses_ProductId",
                table: "ProfitLosses");

            migrationBuilder.DropIndex(
                name: "IX_ProfitLosses_SaleId",
                table: "ProfitLosses");

            migrationBuilder.DropColumn(
                name: "DailyMaterialUseId",
                table: "ProfitLosses");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProfitLosses");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "ProfitLosses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DailyMaterialUseId",
                table: "ProfitLosses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProfitLosses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "ProfitLosses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProfitLosses_DailyMaterialUseId",
                table: "ProfitLosses",
                column: "DailyMaterialUseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfitLosses_ProductId",
                table: "ProfitLosses",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfitLosses_SaleId",
                table: "ProfitLosses",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfitLosses_DailyMaterialsUsed_DailyMaterialUseId",
                table: "ProfitLosses",
                column: "DailyMaterialUseId",
                principalTable: "DailyMaterialsUsed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfitLosses_Products_ProductId",
                table: "ProfitLosses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfitLosses_Sales_SaleId",
                table: "ProfitLosses",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
