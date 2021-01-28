using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserLogin.Migrations
{
    public partial class KeyTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "StreetNumber",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Zipcode",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GarageSales",
                columns: table => new
                {
                    GarageSaleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StreetNumber = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Zipcode = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageSales", x => x.GarageSaleId);
                    table.ForeignKey(
                        name: "FK_GarageSales_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ReviewerId = table.Column<int>(nullable: false),
                    ReviewedId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewedId",
                        column: x => x.ReviewedId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLists",
                columns: table => new
                {
                    UserListId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FollowerId = table.Column<int>(nullable: false),
                    FollowingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLists", x => x.UserListId);
                    table.ForeignKey(
                        name: "FK_UserLists_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLists_Users_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarageLists",
                columns: table => new
                {
                    GarageListId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    GarageSaleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageLists", x => x.GarageListId);
                    table.ForeignKey(
                        name: "FK_GarageLists_GarageSales_GarageSaleId",
                        column: x => x.GarageSaleId,
                        principalTable: "GarageSales",
                        principalColumn: "GarageSaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarageLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GarageLists_GarageSaleId",
                table: "GarageLists",
                column: "GarageSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_GarageLists_UserId",
                table: "GarageLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GarageSales_UserId",
                table: "GarageSales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewedId",
                table: "Reviews",
                column: "ReviewedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLists_FollowerId",
                table: "UserLists",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLists_FollowingId",
                table: "UserLists",
                column: "FollowingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarageLists");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserLists");

            migrationBuilder.DropTable(
                name: "GarageSales");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
