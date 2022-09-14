using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class MeargeAut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationADAssignedGroup_AuthenticationADAssignedGroupsid",
                table: "AuthenticationADAssignedGroupAuthenticationClaimRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthenticationADAssignedGroup",
                table: "AuthenticationADAssignedGroup");

            migrationBuilder.RenameTable(
                name: "AuthenticationADAssignedGroup",
                newName: "AuthenticationADAssignedGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthenticationADAssignedGroups",
                table: "AuthenticationADAssignedGroups",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationADAssignedGroups_AuthenticationADAssignedGroupsid",
                table: "AuthenticationADAssignedGroupAuthenticationClaimRequirement",
                column: "AuthenticationADAssignedGroupsid",
                principalTable: "AuthenticationADAssignedGroups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationADAssignedGroups_AuthenticationADAssignedGroupsid",
                table: "AuthenticationADAssignedGroupAuthenticationClaimRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthenticationADAssignedGroups",
                table: "AuthenticationADAssignedGroups");

            migrationBuilder.RenameTable(
                name: "AuthenticationADAssignedGroups",
                newName: "AuthenticationADAssignedGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthenticationADAssignedGroup",
                table: "AuthenticationADAssignedGroup",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationADAssignedGroup_AuthenticationADAssignedGroupsid",
                table: "AuthenticationADAssignedGroupAuthenticationClaimRequirement",
                column: "AuthenticationADAssignedGroupsid",
                principalTable: "AuthenticationADAssignedGroup",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
