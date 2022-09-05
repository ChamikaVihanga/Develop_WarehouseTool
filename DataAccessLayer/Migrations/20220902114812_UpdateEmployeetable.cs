using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdateEmployeetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "VS_Employees_1",
                newName: "SapNo");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "VS_Employees_1",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "VS_Employees_1",
                newName: "OrganizationalUnitID");

            migrationBuilder.AddColumn<string>(
                name: "CostCenterID",
                table: "VS_Employees_1",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CostCenterName",
                table: "VS_Employees_1",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "VS_Employees_1",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AuthenticationADAssignedGroup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADGroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationADAssignedGroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationADAssignedGroupAuthenticationClaimRequirement",
                columns: table => new
                {
                    AuthenticationADAssignedGroupsid = table.Column<int>(type: "int", nullable: false),
                    authenticationClaimRequirementsRequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationADAssignedGroupAuthenticationClaimRequirement", x => new { x.AuthenticationADAssignedGroupsid, x.authenticationClaimRequirementsRequirementId });
                    table.ForeignKey(
                        name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationADAssignedGroup_AuthenticationADAssignedGroupsid",
                        column: x => x.AuthenticationADAssignedGroupsid,
                        principalTable: "AuthenticationADAssignedGroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationClaimRequirements_authenticationClaimRequirementsR~",
                        column: x => x.authenticationClaimRequirementsRequirementId,
                        principalTable: "AuthenticationClaimRequirements",
                        principalColumn: "RequirementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationADAssignedGroupAuthenticationClaimRequirement_authenticationClaimRequirementsRequirementId",
                table: "AuthenticationADAssignedGroupAuthenticationClaimRequirement",
                column: "authenticationClaimRequirementsRequirementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroupAuthenticationClaimRequirement");

            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroup");

            migrationBuilder.DropColumn(
                name: "CostCenterID",
                table: "VS_Employees_1");

            migrationBuilder.DropColumn(
                name: "CostCenterName",
                table: "VS_Employees_1");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "VS_Employees_1");

            migrationBuilder.RenameColumn(
                name: "SapNo",
                table: "VS_Employees_1",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "VS_Employees_1",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "OrganizationalUnitID",
                table: "VS_Employees_1",
                newName: "Address");
        }
    }
}
