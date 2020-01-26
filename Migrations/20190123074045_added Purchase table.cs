using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class addedPurchasetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "MaterialStocks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialStocks_PurchaseId",
                table: "MaterialStocks",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialStocks_Purchases_PurchaseId",
                table: "MaterialStocks",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialStocks_Purchases_PurchaseId",
                table: "MaterialStocks");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_MaterialStocks_PurchaseId",
                table: "MaterialStocks");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "MaterialStocks");
        }
    }
}
