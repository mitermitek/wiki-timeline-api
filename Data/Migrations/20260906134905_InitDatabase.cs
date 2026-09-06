using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace wiki_timeline_api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailyGames",
                columns: table => new
                {
                    DailyGameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyGames", x => x.DailyGameID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailyGameCards",
                columns: table => new
                {
                    DailyGameCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DailyGameID = table.Column<int>(type: "int", nullable: false),
                    WikiID = table.Column<int>(type: "int", nullable: false),
                    WikiTitle = table.Column<string>(type: "longtext", nullable: false),
                    WikiImageUrl = table.Column<string>(type: "longtext", nullable: false),
                    WikiProperty = table.Column<string>(type: "longtext", nullable: false),
                    EventDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EventDateType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyGameCards", x => x.DailyGameCardID);
                    table.ForeignKey(
                        name: "FK_DailyGameCards_DailyGames_DailyGameID",
                        column: x => x.DailyGameID,
                        principalTable: "DailyGames",
                        principalColumn: "DailyGameID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    UserGameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DailyGameID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    TimeTaken = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.UserGameID);
                    table.ForeignKey(
                        name: "FK_UserGames_DailyGames_DailyGameID",
                        column: x => x.DailyGameID,
                        principalTable: "DailyGames",
                        principalColumn: "DailyGameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DailyGameCards_DailyGameID",
                table: "DailyGameCards",
                column: "DailyGameID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_DailyGameID",
                table: "UserGames",
                column: "DailyGameID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserID",
                table: "UserGames",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyGameCards");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "DailyGames");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
