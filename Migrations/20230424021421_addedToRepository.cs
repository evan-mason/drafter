using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drafter.Migrations
{
    /// <inheritdoc />
    public partial class addedToRepository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DraftId",
                table: "FantasyTeams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drafts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Picks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickNumber = table.Column<int>(type: "int", nullable: false),
                    PickTakenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FantasyTeamId = table.Column<int>(type: "int", nullable: false),
                    DraftId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picks_Drafts_DraftId",
                        column: x => x.DraftId,
                        principalTable: "Drafts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Picks_FantasyTeams_FantasyTeamId",
                        column: x => x.FantasyTeamId,
                        principalTable: "FantasyTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DraftId",
                table: "FantasyTeams",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Picks_DraftId",
                table: "Picks",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Picks_FantasyTeamId",
                table: "Picks",
                column: "FantasyTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Drafts_DraftId",
                table: "FantasyTeams",
                column: "DraftId",
                principalTable: "Drafts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Drafts_DraftId",
                table: "FantasyTeams");

            migrationBuilder.DropTable(
                name: "Picks");

            migrationBuilder.DropTable(
                name: "Drafts");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_DraftId",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "DraftId",
                table: "FantasyTeams");
        }
    }
}
