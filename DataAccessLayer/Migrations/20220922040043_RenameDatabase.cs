using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class RenameDatabase : Migration
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
                name: "IX_OperationRecords_VS_EmployeesId",
                table: "OperationRecords");

            migrationBuilder.DropIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VS_Employees");

            migrationBuilder.DropColumn(
                name: "VS_EmployeesId",
                table: "OperationRecords");

            migrationBuilder.DropColumn(
                name: "AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.RenameTable(
                name: "VS_Employees",
                newName: "Vs_Employees");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationalUnit",
                table: "Vs_Employees",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Vs_Employees",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Vs_Employees",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SAPNo",
                table: "Vs_Employees",
                type: "varchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Vs_Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostCenterID",
                table: "Vs_Employees",
                type: "varchar(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostCenterName",
                table: "Vs_Employees",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Vs_Employees",
                type: "varchar(4)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EPFNo",
                table: "Vs_Employees",
                type: "varchar(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpLevel",
                table: "Vs_Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeStatus",
                table: "Vs_Employees",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Initials",
                table: "Vs_Employees",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "Vs_Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Vs_Employees",
                type: "varchar(7)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Vs_Employees",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationalUnitID",
                table: "Vs_Employees",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RFID",
                table: "Vs_Employees",
                type: "varchar(8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Vs_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salutation",
                table: "Vs_Employees",
                type: "varchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SysUserID",
                table: "Vs_Employees",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkContract",
                table: "Vs_Employees",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SAPNo",
                table: "OperationRecords",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "AuthenticationADAssignedGroups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADGroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationADAssignedGroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SapPlants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    Level = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    SapNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostCenterID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostCenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationalUnitID = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationADAssignedGroups_AuthenticationADAssignedGroupsid",
                        column: x => x.AuthenticationADAssignedGroupsid,
                        principalTable: "AuthenticationADAssignedGroups",
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
                name: "SapCostCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SapPlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapCostCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SapCostCenters_SapPlants_SapPlantId",
                        column: x => x.SapPlantId,
                        principalTable: "SapPlants",
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
                name: "SapOrganizationalUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SapCostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapOrganizationalUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SapOrganizationalUnits_SapCostCenters_SapCostCenterId",
                        column: x => x.SapCostCenterId,
                        principalTable: "SapCostCenters",
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

            migrationBuilder.CreateTable(
                name: "SapEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SapNo = table.Column<int>(type: "int", nullable: false),
                    EpfNo = table.Column<int>(type: "int", nullable: true),
                    Rfid = table.Column<int>(type: "int", nullable: true),
                    LogonId = table.Column<string>(type: "varchar(20)", nullable: true),
                    Salutaion = table.Column<string>(type: "varchar(10)", nullable: true),
                    Initials = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Position = table.Column<string>(type: "varchar(100)", nullable: true),
                    WorkContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "varchar(20)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<string>(type: "varchar(20)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "varchar(100)", nullable: true),
                    EmployeeStatus = table.Column<string>(type: "varchar(100)", nullable: true),
                    Source = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SapOrganizationalUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SapPlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SapWorkContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SapEmployee_SapOrganizationalUnits_SapOrganizationalUnitId",
                        column: x => x.SapOrganizationalUnitId,
                        principalTable: "SapOrganizationalUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SapEmployee_SapPlants_SapPlantId",
                        column: x => x.SapPlantId,
                        principalTable: "SapPlants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SapEmployee_SapWorkContracts_SapWorkContractId",
                        column: x => x.SapWorkContractId,
                        principalTable: "SapWorkContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthenticationHttpMethods",
                columns: new[] { "Id", "HttpMethod" },
                values: new object[,]
                {
                    { 1, "GET" },
                    { 2, "POST" },
                    { 3, "PUT" },
                    { 4, "DELETE" },
                    { 5, "PATCH" }
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
                name: "IX_SapCostCenters_SapPlantId",
                table: "SapCostCenters",
                column: "SapPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapOrganizationalUnitId",
                table: "SapEmployee",
                column: "SapOrganizationalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapPlantId",
                table: "SapEmployee",
                column: "SapPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapWorkContractId",
                table: "SapEmployee",
                column: "SapWorkContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SapOrganizationalUnits_SapCostCenterId",
                table: "SapOrganizationalUnits",
                column: "SapCostCenterId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodsId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroupAuthenticationClaimRequirement");

            migrationBuilder.DropTable(
                name: "SapEmployee");

            migrationBuilder.DropTable(
                name: "ShiftGroupVS_Employees_1");

            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroups");

            migrationBuilder.DropTable(
                name: "SapOrganizationalUnits");

            migrationBuilder.DropTable(
                name: "SapWorkContracts");

            migrationBuilder.DropTable(
                name: "ShiftGroups");

            migrationBuilder.DropTable(
                name: "VS_Employees_1");

            migrationBuilder.DropTable(
                name: "SapCostCenters");

            migrationBuilder.DropTable(
                name: "WorkingShift");

            migrationBuilder.DropTable(
                name: "SapPlants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vs_Employees",
                table: "Vs_Employees");

            migrationBuilder.DropIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodsId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 5);

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
                name: "EmpLevel",
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
                name: "SAPNo",
                table: "OperationRecords");

            migrationBuilder.DropColumn(
                name: "OrganizationUnit",
                table: "OperationDetails");

            migrationBuilder.RenameTable(
                name: "Vs_Employees",
                newName: "VS_Employees");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationalUnit",
                table: "VS_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "VS_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "VS_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "VS_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VS_Employees",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "VS_EmployeesId",
                table: "OperationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_OperationRecords_VS_EmployeesId",
                table: "OperationRecords",
                column: "VS_EmployeesId");

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
