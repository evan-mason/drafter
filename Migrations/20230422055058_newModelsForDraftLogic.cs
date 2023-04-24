using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drafter.Migrations
{
    /// <inheritdoc />
    public partial class newModelsForDraftLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Points",
                table: "Players",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<double>(
                name: "AST",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "BLK",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DRB",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FGA",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FGM",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FGP",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FreeThrowPA",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FreeThrowPG",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FreeThrowPP",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "GamesPL",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesStarted",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Minutes",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ORB",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "STL",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TOV",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TRB",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThreePA",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThreePM",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThreePP",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TwoPA",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TwoPM",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TwoPP",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AST",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BLK",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DRB",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FGA",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FGM",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FGP",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FreeThrowPA",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FreeThrowPG",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FreeThrowPP",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GamesPL",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GamesStarted",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ORB",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "STL",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TOV",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TRB",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ThreePA",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ThreePM",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ThreePP",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TwoPA",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TwoPM",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TwoPP",
                table: "Players");

            migrationBuilder.AlterColumn<decimal>(
                name: "Points",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
