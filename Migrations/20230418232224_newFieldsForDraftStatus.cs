using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drafter.Migrations
{
    /// <inheritdoc />
    public partial class newFieldsForDraftStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DraftPosition",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftTime",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DraftPosition",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DraftTime",
                table: "Players");
        }
    }
}
