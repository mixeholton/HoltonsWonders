using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MixeWonders.ClientServer.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAffiliationRolesGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffiliationGroups");

            migrationBuilder.DropTable(
                name: "AffiliationRoles");

            migrationBuilder.AlterColumn<int>(
                name: "AffiliationId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AffiliationEntityId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AffiliationEntityId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AffiliationEntityId",
                table: "Roles",
                column: "AffiliationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AffiliationEntityId",
                table: "Groups",
                column: "AffiliationEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Affiliations_AffiliationEntityId",
                table: "Groups",
                column: "AffiliationEntityId",
                principalTable: "Affiliations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Affiliations_AffiliationEntityId",
                table: "Roles",
                column: "AffiliationEntityId",
                principalTable: "Affiliations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Affiliations_AffiliationEntityId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Affiliations_AffiliationEntityId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_AffiliationEntityId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Groups_AffiliationEntityId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AffiliationEntityId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AffiliationEntityId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "AffiliationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AffiliationGroups",
                columns: table => new
                {
                    AffiliationId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliationGroups", x => new { x.AffiliationId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_AffiliationGroups_Affiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "Affiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffiliationGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffiliationRoles",
                columns: table => new
                {
                    AffiliationId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliationRoles", x => new { x.AffiliationId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AffiliationRoles_Affiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "Affiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffiliationRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffiliationGroups_GroupId",
                table: "AffiliationGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliationRoles_RoleId",
                table: "AffiliationRoles",
                column: "RoleId");
        }
    }
}
