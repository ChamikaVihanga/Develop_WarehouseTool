using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class SapExtraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "OperationLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReFaRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReFaRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleTodos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTodos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SapCostCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapCostCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SapEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SapNo = table.Column<int>(type: "int", nullable: false),
                    EpfNo = table.Column<int>(type: "int", nullable: false),
                    Rfid = table.Column<int>(type: "int", nullable: false),
                    LogonId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salutaion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationalUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlantInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SapOrganizationalUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SapCostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapOrganizationalUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SapPlants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapPlants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SapWorkContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapWorkContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VS_Employees_1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationalUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VS_Employees_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodsId",
                        column: x => x.AuthenticationHttpMethodsId,
                        principalTable: "AuthenticationHttpMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationListId = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: true),
                    TimeSpan = table.Column<int>(type: "int", nullable: true),
                    TimePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationDetails_OperationLists_OperationListId",
                        column: x => x.OperationListId,
                        principalTable: "OperationLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationListId = table.Column<int>(type: "int", nullable: true),
                    VS_EmployeesId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Achivement = table.Column<int>(type: "int", nullable: true),
                    Efficiency = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationRecords_OperationLists_OperationListId",
                        column: x => x.OperationListId,
                        principalTable: "OperationLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperationRecords_VS_Employees_1_VS_EmployeesId",
                        column: x => x.VS_EmployeesId,
                        principalTable: "VS_Employees_1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ShiftGroupVS_Employees_1",
                columns: table => new
                {
                    VS_EmployeesId = table.Column<int>(type: "int", nullable: false),
                    shiftGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftGroupVS_Employees_1", x => new { x.VS_EmployeesId, x.shiftGroupsId });
                    table.ForeignKey(
                        name: "FK_ShiftGroupVS_Employees_1_ShiftGroups_shiftGroupsId",
                        column: x => x.shiftGroupsId,
                        principalTable: "ShiftGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftGroupVS_Employees_1_VS_Employees_1_VS_EmployeesId",
                        column: x => x.VS_EmployeesId,
                        principalTable: "VS_Employees_1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationADAssignedGroupAuthenticationClaimRequirement_authenticationClaimRequirementsRequirementId",
                table: "AuthenticationADAssignedGroupAuthenticationClaimRequirement",
                column: "authenticationClaimRequirementsRequirementId");

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
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodsId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimValueAuthenticationUserClaimsHolder_authenticationClaimValuesClaimValueId",
                table: "AuthenticationClaimValueAuthenticationUserClaimsHolder",
                column: "authenticationClaimValuesClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimValues_AuthenticationClaimId",
                table: "AuthenticationClaimValues",
                column: "AuthenticationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationDetails_OperationListId",
                table: "OperationDetails",
                column: "OperationListId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationRecords_OperationListId",
                table: "OperationRecords",
                column: "OperationListId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationRecords_VS_EmployeesId",
                table: "OperationRecords",
                column: "VS_EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftGroups_WorkingShiftsId",
                table: "ShiftGroups",
                column: "WorkingShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftGroupVS_Employees_1_shiftGroupsId",
                table: "ShiftGroupVS_Employees_1",
                column: "shiftGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroupAuthenticationClaimRequirement");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimGroupAuthenticationClaimValue");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimRequirementAuthenticationClaimValue");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimValueAuthenticationUserClaimsHolder");

            migrationBuilder.DropTable(
                name: "OperationDetails");

            migrationBuilder.DropTable(
                name: "OperationRecords");

            migrationBuilder.DropTable(
                name: "ReFaRequests");

            migrationBuilder.DropTable(
                name: "SampleTodos");

            migrationBuilder.DropTable(
                name: "SapCostCenters");

            migrationBuilder.DropTable(
                name: "SapEmployee");

            migrationBuilder.DropTable(
                name: "SapOrganizationalUnits");

            migrationBuilder.DropTable(
                name: "SapPlants");

            migrationBuilder.DropTable(
                name: "SapWorkContracts");

            migrationBuilder.DropTable(
                name: "ShiftGroupVS_Employees_1");

            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroup");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimRequirements");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimValues");

            migrationBuilder.DropTable(
                name: "AuthenticationUserClaimsHolders");

            migrationBuilder.DropTable(
                name: "OperationLists");

            migrationBuilder.DropTable(
                name: "ShiftGroups");

            migrationBuilder.DropTable(
                name: "VS_Employees_1");

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
