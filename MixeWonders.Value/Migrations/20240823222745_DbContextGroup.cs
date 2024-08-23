using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MixeWonders.Value.Migrations
{
    /// <inheritdoc />
    public partial class DbContextGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleEntityId",
                table: "Permissions");

            migrationBuilder.RenameColumn(
                name: "RoleEntityId",
                table: "Permissions",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_RoleEntityId",
                table: "Permissions",
                newName: "IX_Permissions_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Permissions",
                newName: "RoleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                newName: "IX_Permissions_RoleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleEntityId",
                table: "Permissions",
                column: "RoleEntityId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
