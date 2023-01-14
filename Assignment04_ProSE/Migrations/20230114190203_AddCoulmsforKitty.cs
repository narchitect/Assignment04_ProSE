using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment04ProSE.Migrations
{
    /// <inheritdoc />
    public partial class AddCoulmsforKitty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParticipantName",
                table: "Participants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CreatorName",
                table: "Kitties",
                newName: "Link");

            migrationBuilder.AddColumn<double>(
                name: "CurrentDebt",
                table: "Participants",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Participants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Participants",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Participants",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GroupCost",
                table: "Kitties",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "HomeCurrency",
                table: "Kitties",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentDebt",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "GroupCost",
                table: "Kitties");

            migrationBuilder.DropColumn(
                name: "HomeCurrency",
                table: "Kitties");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Participants",
                newName: "ParticipantName");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Kitties",
                newName: "CreatorName");
        }
    }
}
