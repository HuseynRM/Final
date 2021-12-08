using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedSettingTable_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(maxLength: 4000, nullable: true),
                    Phone = table.Column<string>(maxLength: 4000, nullable: true),
                    Mail = table.Column<string>(maxLength: 4000, nullable: true),
                    Facebook = table.Column<string>(maxLength: 4000, nullable: true),
                    Twitter = table.Column<string>(maxLength: 4000, nullable: true),
                    Google = table.Column<string>(maxLength: 4000, nullable: true),
                    YouTube = table.Column<string>(maxLength: 4000, nullable: true),
                    Pinteres = table.Column<string>(maxLength: 4000, nullable: true),
                    LinkIn = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
