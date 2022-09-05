using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class SAPDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationRecords_VS_Employees_VS_EmployeesId",
                table: "OperationRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VS_Employees",
                table: "VS_Employees");

            migrationBuilder.DropIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.DropColumn(
                name: "AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.RenameTable(
                name: "VS_Employees",
                newName: "Vs_Employees");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vs_Employees",
                newName: "EmpLevel");

            migrationBuilder.AlterColumn<int>(
                name: "EmpLevel",
                table: "Vs_Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "SAPNo",
                table: "Vs_Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Vs_Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CostCenterID",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CostCenterName",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EPFNo",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeStatus",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Initials",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "Vs_Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationalUnitID",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RFID",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salutation",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SysUserID",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkContract",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationUnit",
                table: "OperationDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vs_Employees",
                table: "Vs_Employees",
                column: "SAPNo");

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
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodsId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationADAssignedGroupAuthenticationClaimRequirement_authenticationClaimRequirementsRequirementId",
                table: "AuthenticationADAssignedGroupAuthenticationClaimRequirement",
                column: "authenticationClaimRequirementsRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftGroups_WorkingShiftsId",
                table: "ShiftGroups",
                column: "WorkingShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftGroupVS_Employees_1_shiftGroupsId",
                table: "ShiftGroupVS_Employees_1",
                column: "shiftGroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodsId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodsId",
                principalTable: "AuthenticationHttpMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationRecords_VS_Employees_1_VS_EmployeesId",
                table: "OperationRecords",
                column: "VS_EmployeesId",
                principalTable: "VS_Employees_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodsId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationRecords_VS_Employees_1_VS_EmployeesId",
                table: "OperationRecords");

            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroupAuthenticationClaimRequirement");

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
                name: "ShiftGroups");

            migrationBuilder.DropTable(
                name: "VS_Employees_1");

            migrationBuilder.DropTable(
                name: "WorkingShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vs_Employees",
                table: "Vs_Employees");

            migrationBuilder.DropIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodsId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.DropColumn(
                name: "SAPNo",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "CostCenterID",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "CostCenterName",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "EPFNo",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeStatus",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "Initials",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationalUnitID",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "RFID",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "Salutation",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "SysUserID",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "WorkContract",
                table: "Vs_Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationUnit",
                table: "OperationDetails");

            migrationBuilder.RenameTable(
                name: "Vs_Employees",
                newName: "VS_Employees");

            migrationBuilder.RenameColumn(
                name: "EmpLevel",
                table: "VS_Employees",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VS_Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VS_Employees",
                table: "VS_Employees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodId",
                principalTable: "AuthenticationHttpMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationRecords_VS_Employees_VS_EmployeesId",
                table: "OperationRecords",
                column: "VS_EmployeesId",
                principalTable: "VS_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
