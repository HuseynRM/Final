using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedMenuListandCatagory_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCatagories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCatagories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    MenuCatagoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuLists_MenuCatagories_MenuCatagoryId",
                        column: x => x.MenuCatagoryId,
                        principalTable: "MenuCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuLists_MenuCatagoryId",
                table: "MenuLists",
                column: "MenuCatagoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuLists");

            migrationBuilder.DropTable(
                name: "MenuCatagories");
        }
    }
}
