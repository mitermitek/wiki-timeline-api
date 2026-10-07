using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_timeline_api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TotalScore",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "UserGames",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserGames");
        }
    }
}
