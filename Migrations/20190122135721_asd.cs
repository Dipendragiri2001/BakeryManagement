using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSalesAmount",
                table: "ProfitLosses",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "TotalMetarialAmount",
                table: "ProfitLosses",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "DailyMaterialUseId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "ProfitLosses",
                newName: "TotalSalesAmount");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProfitLosses",
                newName: "TotalMetarialAmount");
        }
    }
}
