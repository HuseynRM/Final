using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedSingleProduct_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductSingles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 6000, nullable: true),
                    NewPrice = table.Column<double>(nullable: false),
                    OldPrice = table.Column<double>(nullable: false),
                    SingleDesc = table.Column<string>(maxLength: 6000, nullable: true),
                    Img = table.Column<string>(maxLength: 6000, nullable: true),
                    Isdeleted = table.Column<bool>(nullable: false),
                    LongDesc = table.Column<string>(maxLength: 6000, nullable: true),
                    Desc1 = table.Column<string>(maxLength: 6000, nullable: true),
                    Desc2 = table.Column<string>(maxLength: 6000, nullable: true),
                    Desc3 = table.Column<string>(maxLength: 6000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSingles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSingles");
        }
    }
}
