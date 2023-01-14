using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment04ProSE.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    KittyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Kitties_KittyId",
                        column: x => x.KittyId,
                        principalTable: "Kitties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_KittyId",
                table: "Comments",
                column: "KittyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParticipantId",
                table: "Comments",
                column: "ParticipantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
