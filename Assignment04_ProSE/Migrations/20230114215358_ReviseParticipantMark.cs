using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment04ProSE.Migrations
{
    /// <inheritdoc />
    public partial class ReviseParticipantMark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentDebt",
                table: "Participants");

            migrationBuilder.AddColumn<bool>(
                name: "Mark",
                table: "Participants",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Participants");

            migrationBuilder.AddColumn<double>(
                name: "CurrentDebt",
                table: "Participants",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
