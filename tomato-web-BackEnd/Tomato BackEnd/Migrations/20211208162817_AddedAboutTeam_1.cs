using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedAboutTeam_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamImg = table.Column<string>(maxLength: 3000, nullable: true),
                    CookName = table.Column<string>(maxLength: 3000, nullable: true),
                    Designation = table.Column<string>(maxLength: 3000, nullable: true),
                    Facebook = table.Column<string>(maxLength: 3000, nullable: true),
                    Twiter = table.Column<string>(maxLength: 3000, nullable: true),
                    Google = table.Column<string>(maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutTeams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutTeams");
        }
    }
}
