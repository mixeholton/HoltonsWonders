using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MixeWonders.ClientServer.Migrations
{
    /// <inheritdoc />
    public partial class stable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Affiliations_AffiliationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AffiliationId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Affiliations_UserId",
                table: "Affiliations",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliations_Users_UserId",
                table: "Affiliations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affiliations_Users_UserId",
                table: "Affiliations");

            migrationBuilder.DropIndex(
                name: "IX_Affiliations_UserId",
                table: "Affiliations");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AffiliationId",
                table: "Users",
                column: "AffiliationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Affiliations_AffiliationId",
                table: "Users",
                column: "AffiliationId",
                principalTable: "Affiliations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
