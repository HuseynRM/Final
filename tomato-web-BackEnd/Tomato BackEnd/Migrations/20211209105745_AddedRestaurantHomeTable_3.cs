using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedRestaurantHomeTable_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeImg1",
                table: "RestaurantHomes",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeImg2",
                table: "RestaurantHomes",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeImg1",
                table: "RestaurantHomes");

            migrationBuilder.DropColumn(
                name: "HomeImg2",
                table: "RestaurantHomes");
        }
    }
}
