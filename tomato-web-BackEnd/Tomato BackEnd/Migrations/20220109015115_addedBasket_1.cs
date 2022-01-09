using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class addedBasket_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_ProductSingles_ProductSingleId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ProductSingleId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ProductSingleId",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "ShopListId",
                table: "Baskets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ShopListId",
                table: "Baskets",
                column: "ShopListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_ShopLists_ShopListId",
                table: "Baskets",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_ShopLists_ShopListId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ShopListId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ShopListId",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "ProductSingleId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductSingleId",
                table: "Baskets",
                column: "ProductSingleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_ProductSingles_ProductSingleId",
                table: "Baskets",
                column: "ProductSingleId",
                principalTable: "ProductSingles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
