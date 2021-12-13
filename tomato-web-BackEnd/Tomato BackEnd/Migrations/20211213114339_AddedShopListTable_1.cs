using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedShopListTable_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(maxLength: 5000, nullable: true),
                    FName = table.Column<string>(maxLength: 5000, nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ShopCatagoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopLists_ShopCatagories_ShopCatagoryId",
                        column: x => x.ShopCatagoryId,
                        principalTable: "ShopCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_ShopCatagoryId",
                table: "ShopLists",
                column: "ShopCatagoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopLists");
        }
    }
}
