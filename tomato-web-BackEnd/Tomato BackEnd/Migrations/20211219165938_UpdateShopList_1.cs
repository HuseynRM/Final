using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class UpdateShopList_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopLists_ProductSingles_ProductSingleId",
                table: "ShopLists");

            migrationBuilder.DropIndex(
                name: "IX_ShopLists_ProductSingleId",
                table: "ShopLists");

            migrationBuilder.AddColumn<int>(
                name: "ShopListId",
                table: "ProductSingles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSingles_ShopListId",
                table: "ProductSingles",
                column: "ShopListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSingles_ShopLists_ShopListId",
                table: "ProductSingles",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSingles_ShopLists_ShopListId",
                table: "ProductSingles");

            migrationBuilder.DropIndex(
                name: "IX_ProductSingles_ShopListId",
                table: "ProductSingles");

            migrationBuilder.DropColumn(
                name: "ShopListId",
                table: "ProductSingles");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_ProductSingleId",
                table: "ShopLists",
                column: "ProductSingleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopLists_ProductSingles_ProductSingleId",
                table: "ShopLists",
                column: "ProductSingleId",
                principalTable: "ProductSingles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
