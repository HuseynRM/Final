using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedSomeColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ShopLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ShopLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_AppUserId",
                table: "ShopLists",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopLists_AspNetUsers_AppUserId",
                table: "ShopLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopLists_AspNetUsers_AppUserId",
                table: "ShopLists");

            migrationBuilder.DropIndex(
                name: "IX_ShopLists_AppUserId",
                table: "ShopLists");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ShopLists");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "ShopLists");
        }
    }
}
