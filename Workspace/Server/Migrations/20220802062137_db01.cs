using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workspace.Server.Migrations
{
    public partial class db01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "VS_Employees",
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
                    table.PrimaryKey("PK_VS_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationDetailes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationListId = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false),
                    TimeSpan = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationDetailes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationDetailes_OperationLists_OperationListId",
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
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Achivement = table.Column<int>(type: "int", nullable: true),
                    Efficiency = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_OperationRecords_VS_Employees_VS_EmployeesId",
                        column: x => x.VS_EmployeesId,
                        principalTable: "VS_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationDetailes_OperationListId",
                table: "OperationDetailes",
                column: "OperationListId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationRecords_OperationListId",
                table: "OperationRecords",
                column: "OperationListId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationRecords_VS_EmployeesId",
                table: "OperationRecords",
                column: "VS_EmployeesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationDetailes");

            migrationBuilder.DropTable(
                name: "OperationRecords");

            migrationBuilder.DropTable(
                name: "ReFaRequests");

            migrationBuilder.DropTable(
                name: "OperationLists");

            migrationBuilder.DropTable(
                name: "VS_Employees");
        }
    }
}
