using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class yyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticationClaimGroups",
                columns: table => new
                {
                    ClaimGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimGroups", x => x.ClaimGroupId);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Claim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaims", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationHttpMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationHttpMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationUserClaimsHolders",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationUserClaimsHolders", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimValues",
                columns: table => new
                {
                    ClaimValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthenticationClaimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimValues", x => x.ClaimValueId);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimValues_AuthenticationClaims_AuthenticationClaimId",
                        column: x => x.AuthenticationClaimId,
                        principalTable: "AuthenticationClaims",
                        principalColumn: "ClaimId");
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimRequirements",
                columns: table => new
                {
                    RequirementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    beenReviewed = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthenticationHttpMethodsId = table.Column<int>(type: "int", nullable: true),
                    AuthenticationHttpMethodId = table.Column<int>(type: "int", nullable: true),
                    AuthenticationClaimGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimRequirements", x => x.RequirementId);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimRequirements_AuthenticationClaimGroups_AuthenticationClaimGroupId",
                        column: x => x.AuthenticationClaimGroupId,
                        principalTable: "AuthenticationClaimGroups",
                        principalColumn: "ClaimGroupId");
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodId",
                        column: x => x.AuthenticationHttpMethodId,
                        principalTable: "AuthenticationHttpMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShiftGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkingShiftId = table.Column<int>(type: "int", nullable: false),
                    WorkingShiftsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftGroups_WorkingShift_WorkingShiftsId",
                        column: x => x.WorkingShiftsId,
                        principalTable: "WorkingShift",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimGroupAuthenticationClaimValue",
                columns: table => new
                {
                    AuthenticationClaimGroupsClaimGroupId = table.Column<int>(type: "int", nullable: false),
                    AuthenticationClaimValuesClaimValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimGroupAuthenticationClaimValue", x => new { x.AuthenticationClaimGroupsClaimGroupId, x.AuthenticationClaimValuesClaimValueId });
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimGroupAuthenticationClaimValue_AuthenticationClaimGroups_AuthenticationClaimGroupsClaimGroupId",
                        column: x => x.AuthenticationClaimGroupsClaimGroupId,
                        principalTable: "AuthenticationClaimGroups",
                        principalColumn: "ClaimGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimGroupAuthenticationClaimValue_AuthenticationClaimValues_AuthenticationClaimValuesClaimValueId",
                        column: x => x.AuthenticationClaimValuesClaimValueId,
                        principalTable: "AuthenticationClaimValues",
                        principalColumn: "ClaimValueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimValueAuthenticationUserClaimsHolder",
                columns: table => new
                {
                    AuthenticationUserClaimsHoldersUserId = table.Column<int>(type: "int", nullable: false),
                    authenticationClaimValuesClaimValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimValueAuthenticationUserClaimsHolder", x => new { x.AuthenticationUserClaimsHoldersUserId, x.authenticationClaimValuesClaimValueId });
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimValueAuthenticationUserClaimsHolder_AuthenticationClaimValues_authenticationClaimValuesClaimValueId",
                        column: x => x.authenticationClaimValuesClaimValueId,
                        principalTable: "AuthenticationClaimValues",
                        principalColumn: "ClaimValueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimValueAuthenticationUserClaimsHolder_AuthenticationUserClaimsHolders_AuthenticationUserClaimsHoldersUserId",
                        column: x => x.AuthenticationUserClaimsHoldersUserId,
                        principalTable: "AuthenticationUserClaimsHolders",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimRequirementAuthenticationClaimValue",
                columns: table => new
                {
                    AuthenticationClaimsRequirementsRequirementId = table.Column<int>(type: "int", nullable: false),
                    authenticationClaimValuesClaimValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimRequirementAuthenticationClaimValue", x => new { x.AuthenticationClaimsRequirementsRequirementId, x.authenticationClaimValuesClaimValueId });
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimRequirementAuthenticationClaimValue_AuthenticationClaimRequirements_AuthenticationClaimsRequirementsRequi~",
                        column: x => x.AuthenticationClaimsRequirementsRequirementId,
                        principalTable: "AuthenticationClaimRequirements",
                        principalColumn: "RequirementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimRequirementAuthenticationClaimValue_AuthenticationClaimValues_authenticationClaimValuesClaimValueId",
                        column: x => x.authenticationClaimValuesClaimValueId,
                        principalTable: "AuthenticationClaimValues",
                        principalColumn: "ClaimValueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftGroupVS_Employees",
                columns: table => new
                {
                    VS_EmployeesId = table.Column<int>(type: "int", nullable: false),
                    shiftGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftGroupVS_Employees", x => new { x.VS_EmployeesId, x.shiftGroupsId });
                    table.ForeignKey(
                        name: "FK_ShiftGroupVS_Employees_ShiftGroups_shiftGroupsId",
                        column: x => x.shiftGroupsId,
                        principalTable: "ShiftGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftGroupVS_Employees_VS_Employees_VS_EmployeesId",
                        column: x => x.VS_EmployeesId,
                        principalTable: "VS_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimGroupAuthenticationClaimValue_AuthenticationClaimValuesClaimValueId",
                table: "AuthenticationClaimGroupAuthenticationClaimValue",
                column: "AuthenticationClaimValuesClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimRequirementAuthenticationClaimValue_authenticationClaimValuesClaimValueId",
                table: "AuthenticationClaimRequirementAuthenticationClaimValue",
                column: "authenticationClaimValuesClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationClaimGroupId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationClaimGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimValueAuthenticationUserClaimsHolder_authenticationClaimValuesClaimValueId",
                table: "AuthenticationClaimValueAuthenticationUserClaimsHolder",
                column: "authenticationClaimValuesClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimValues_AuthenticationClaimId",
                table: "AuthenticationClaimValues",
                column: "AuthenticationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftGroups_WorkingShiftsId",
                table: "ShiftGroups",
                column: "WorkingShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftGroupVS_Employees_shiftGroupsId",
                table: "ShiftGroupVS_Employees",
                column: "shiftGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationClaimGroupAuthenticationClaimValue");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimRequirementAuthenticationClaimValue");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimValueAuthenticationUserClaimsHolder");

            migrationBuilder.DropTable(
                name: "ShiftGroupVS_Employees");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimRequirements");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimValues");

            migrationBuilder.DropTable(
                name: "AuthenticationUserClaimsHolders");

            migrationBuilder.DropTable(
                name: "ShiftGroups");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimGroups");

            migrationBuilder.DropTable(
                name: "AuthenticationHttpMethods");

            migrationBuilder.DropTable(
                name: "AuthenticationClaims");

            migrationBuilder.DropTable(
                name: "WorkingShift");
        }
    }
}
