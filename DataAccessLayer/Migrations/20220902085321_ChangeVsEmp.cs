using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ChangeVsEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationRecords_VS_Employees_VS_EmployeesId",
                table: "OperationRecords");

            migrationBuilder.DropTable(
                name: "VS_Employees");

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
                name: "FK_OperationRecords_VS_Employees_1_VS_EmployeesId",
                table: "OperationRecords");

            migrationBuilder.DropTable(
                name: "VS_Employees_1");

            migrationBuilder.CreateTable(
                name: "VS_Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationalUnit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VS_Employees", x => x.Id);
                });

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
