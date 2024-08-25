using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MixeWonders.Value.Migrations
{
    /// <inheritdoc />
    public partial class Refs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffiliationEntityGroupEntity");

            migrationBuilder.DropTable(
                name: "AffiliationEntityRoleEntity");

            migrationBuilder.DropTable(
                name: "GroupEntityRoleEntity");

            migrationBuilder.DropTable(
                name: "GroupEntityUserEntity");

            migrationBuilder.AddColumn<int>(
                name: "GroupEntityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AffiliationEntityId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupEntityId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AffiliationEntityId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupEntityId",
                table: "Users",
                column: "GroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AffiliationEntityId",
                table: "Roles",
                column: "AffiliationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_GroupEntityId",
                table: "Roles",
                column: "GroupEntityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Groups_GroupEntityId",
                table: "Roles",
                column: "GroupEntityId",
                principalTable: "Groups",
                principalColumn: "Id");

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
                name: "FK_Groups_Affiliations_AffiliationEntityId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Affiliations_AffiliationEntityId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Groups_GroupEntityId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_AffiliationEntityId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_GroupEntityId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Groups_AffiliationEntityId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AffiliationEntityId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "GroupEntityId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AffiliationEntityId",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "AffiliationEntityGroupEntity",
                columns: table => new
                {
                    AffiliationsId = table.Column<int>(type: "int", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliationEntityGroupEntity", x => new { x.AffiliationsId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_AffiliationEntityGroupEntity_Affiliations_AffiliationsId",
                        column: x => x.AffiliationsId,
                        principalTable: "Affiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffiliationEntityGroupEntity_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffiliationEntityRoleEntity",
                columns: table => new
                {
                    AffiliationsId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliationEntityRoleEntity", x => new { x.AffiliationsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_AffiliationEntityRoleEntity_Affiliations_AffiliationsId",
                        column: x => x.AffiliationsId,
                        principalTable: "Affiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffiliationEntityRoleEntity_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupEntityRoleEntity",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntityRoleEntity", x => new { x.GroupsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_GroupEntityRoleEntity_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEntityRoleEntity_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupEntityUserEntity",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntityUserEntity", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupEntityUserEntity_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEntityUserEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffiliationEntityGroupEntity_GroupsId",
                table: "AffiliationEntityGroupEntity",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliationEntityRoleEntity_RolesId",
                table: "AffiliationEntityRoleEntity",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEntityRoleEntity_RolesId",
                table: "GroupEntityRoleEntity",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEntityUserEntity_UsersId",
                table: "GroupEntityUserEntity",
                column: "UsersId");
        }
    }
}
