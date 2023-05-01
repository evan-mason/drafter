using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drafter.Migrations
{
    /// <inheritdoc />
    public partial class draftordertofantasyteam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DraftOrder",
                table: "FantasyTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DraftOrder",
                table: "FantasyTeams");
        }
    }
}
