using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomato_BackEnd.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutStory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryImg = table.Column<string>(maxLength: 3000, nullable: true),
                    StoryContent = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutStory", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AboutTestimonials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteBody = table.Column<string>(maxLength: 5000, nullable: true),
                    QuoteAuthor = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutTestimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 900, nullable: true),
                    Mail = table.Column<string>(maxLength: 900, nullable: true),
                    Subject = table.Column<string>(maxLength: 900, nullable: true),
                    Message = table.Column<string>(maxLength: 9000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureImg = table.Column<string>(maxLength: 4000, nullable: true),
                    Name = table.Column<string>(maxLength: 4000, nullable: true),
                    Desc = table.Column<string>(maxLength: 7000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeSpecials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SepialImg = table.Column<string>(maxLength: 4000, nullable: true),
                    SpecialName = table.Column<string>(maxLength: 4000, nullable: true),
                    Text = table.Column<string>(maxLength: 4000, nullable: true),
                    Text1 = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSpecials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    FullName = table.Column<string>(maxLength: 4000, nullable: false),
                    Date = table.Column<string>(maxLength: 4000, nullable: false),
                    GuestCount = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Mail = table.Column<string>(maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantHomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeImg = table.Column<string>(maxLength: 4000, nullable: true),
                    HomeImg1 = table.Column<string>(maxLength: 4000, nullable: true),
                    HomeImg2 = table.Column<string>(maxLength: 4000, nullable: true),
                    Info1 = table.Column<string>(maxLength: 4000, nullable: true),
                    Info2 = table.Column<string>(maxLength: 4000, nullable: true),
                    Signature = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantHomes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "SpecialService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceIMg = table.Column<string>(maxLength: 3000, nullable: true),
                    ServiceTitle = table.Column<string>(maxLength: 3000, nullable: true),
                    ServiceDesc = table.Column<string>(maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialService", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutStory");

            migrationBuilder.DropTable(
                name: "AboutTeams");

            migrationBuilder.DropTable(
                name: "AboutTestimonials");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "HomeSpecials");

            migrationBuilder.DropTable(
                name: "ReservationInfo");

            migrationBuilder.DropTable(
                name: "RestaurantHomes");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SpecialService");
        }
    }
}
