using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment04ProSE.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCommentKittyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Kitties_KittyId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_KittyId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "KittyId",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KittyId",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_KittyId",
                table: "Comments",
                column: "KittyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Kitties_KittyId",
                table: "Comments",
                column: "KittyId",
                principalTable: "Kitties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
