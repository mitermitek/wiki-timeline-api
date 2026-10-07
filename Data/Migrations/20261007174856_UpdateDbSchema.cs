using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace wiki_timeline_api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyGameCards");

            migrationBuilder.DropColumn(
                name: "Attempts",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "TimeTaken",
                table: "UserGames");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "UserGames",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "UserGames",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ThemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ThemeID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ThemeID = table.Column<int>(type: "int", nullable: false),
                    ExternalID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    ImagePath = table.Column<string>(type: "longtext", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    DateType = table.Column<string>(type: "varchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastUsedAt = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Entities_Themes_ThemeID",
                        column: x => x.ThemeID,
                        principalTable: "Themes",
                        principalColumn: "ThemeID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailyGameEntities",
                columns: table => new
                {
                    DailyGameEntityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DailyGameID = table.Column<int>(type: "int", nullable: false),
                    EntityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyGameEntities", x => x.DailyGameEntityID);
                    table.ForeignKey(
                        name: "FK_DailyGameEntities_DailyGames_DailyGameID",
                        column: x => x.DailyGameID,
                        principalTable: "DailyGames",
                        principalColumn: "DailyGameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyGameEntities_Entities_EntityID",
                        column: x => x.EntityID,
                        principalTable: "Entities",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserGameEntries",
                columns: table => new
                {
                    UserGameEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserGameID = table.Column<int>(type: "int", nullable: false),
                    DailyGameEntityID = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameEntries", x => x.UserGameEntryID);
                    table.ForeignKey(
                        name: "FK_UserGameEntries_DailyGameEntities_DailyGameEntityID",
                        column: x => x.DailyGameEntityID,
                        principalTable: "DailyGameEntities",
                        principalColumn: "DailyGameEntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGameEntries_UserGames_UserGameID",
                        column: x => x.UserGameID,
                        principalTable: "UserGames",
                        principalColumn: "UserGameID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DailyGames_CreationDate",
                table: "DailyGames",
                column: "CreationDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyGameEntities_DailyGameID",
                table: "DailyGameEntities",
                column: "DailyGameID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyGameEntities_EntityID",
                table: "DailyGameEntities",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_ThemeID_ExternalID_DateType",
                table: "Entities",
                columns: new[] { "ThemeID", "ExternalID", "DateType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGameEntries_DailyGameEntityID",
                table: "UserGameEntries",
                column: "DailyGameEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameEntries_UserGameID",
                table: "UserGameEntries",
                column: "UserGameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGameEntries");

            migrationBuilder.DropTable(
                name: "DailyGameEntities");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_DailyGames_CreationDate",
                table: "DailyGames");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "UserGames");

            migrationBuilder.AddColumn<int>(
                name: "Attempts",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeTaken",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DailyGameCards",
                columns: table => new
                {
                    DailyGameCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DailyGameID = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EventDateType = table.Column<int>(type: "int", nullable: false),
                    WikiID = table.Column<int>(type: "int", nullable: false),
                    WikiImageUrl = table.Column<string>(type: "longtext", nullable: false),
                    WikiProperty = table.Column<string>(type: "longtext", nullable: false),
                    WikiTitle = table.Column<string>(type: "longtext", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_DailyGameCards_DailyGameID",
                table: "DailyGameCards",
                column: "DailyGameID");
        }
    }
}
