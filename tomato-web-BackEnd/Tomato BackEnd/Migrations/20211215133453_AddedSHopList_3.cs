using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedSHopList_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductSingleId",
                table: "ShopLists",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopLists_ProductSingles_ProductSingleId",
                table: "ShopLists");

            migrationBuilder.DropIndex(
                name: "IX_ShopLists_ProductSingleId",
                table: "ShopLists");

            migrationBuilder.DropColumn(
                name: "ProductSingleId",
                table: "ShopLists");
        }
    }
}
