using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MixeWonders.Value.Migrations
{
    /// <inheritdoc />
    public partial class UserListInGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupEntityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupEntityId",
                table: "Users",
                column: "GroupEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupEntityId",
                table: "Users",
                column: "GroupEntityId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupEntityId",
                table: "Users");
        }
    }
}
