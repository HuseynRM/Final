using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class UpdateSingleProduct_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OldPrice",
                table: "ProductSingles",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "OldPrice",
                table: "ProductSingles",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
