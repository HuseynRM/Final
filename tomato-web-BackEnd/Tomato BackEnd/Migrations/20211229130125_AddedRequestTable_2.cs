using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class AddedRequestTable_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_AspNetUsers_AppUserId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_ReservationInfo_ReservationInfoId",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ReservationInfoId",
                table: "Requests",
                newName: "IX_Requests_ReservationInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_AppUserId",
                table: "Requests",
                newName: "IX_Requests_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_AppUserId",
                table: "Requests",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ReservationInfo_ReservationInfoId",
                table: "Requests",
                column: "ReservationInfoId",
                principalTable: "ReservationInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_AppUserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ReservationInfo_ReservationInfoId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ReservationInfoId",
                table: "Request",
                newName: "IX_Request_ReservationInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_AppUserId",
                table: "Request",
                newName: "IX_Request_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_AspNetUsers_AppUserId",
                table: "Request",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_ReservationInfo_ReservationInfoId",
                table: "Request",
                column: "ReservationInfoId",
                principalTable: "ReservationInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
