using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class DatabaseRenamingWarehouse_OperationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationDetails");

            migrationBuilder.CreateTable(
                name: "Warehouse_OperationDetails",
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
                    table.PrimaryKey("PK_Warehouse_OperationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_OperationDetails_Warehouse_OperationLists_OperationListId",
                        column: x => x.OperationListId,
                        principalTable: "Warehouse_OperationLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_OperationDetails_OperationListId",
                table: "Warehouse_OperationDetails",
                column: "OperationListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouse_OperationDetails");

            migrationBuilder.CreateTable(
                name: "OperationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationListId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Target = table.Column<int>(type: "int", nullable: true),
                    TimePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSpan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationDetails_Warehouse_OperationLists_OperationListId",
                        column: x => x.OperationListId,
                        principalTable: "Warehouse_OperationLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationDetails_OperationListId",
                table: "OperationDetails",
                column: "OperationListId");
        }
    }
}
