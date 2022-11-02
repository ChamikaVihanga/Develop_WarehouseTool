using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class DatabaseRenamingWarehouse_OperationRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationRecords");

            migrationBuilder.CreateTable(
                name: "Warehouse_OperationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationListId = table.Column<int>(type: "int", nullable: true),
                    SAPNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Achivement = table.Column<int>(type: "int", nullable: true),
                    Efficiency = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse_OperationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_OperationRecords_Warehouse_OperationLists_OperationListId",
                        column: x => x.OperationListId,
                        principalTable: "Warehouse_OperationLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_OperationRecords_OperationListId",
                table: "Warehouse_OperationRecords",
                column: "OperationListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouse_OperationRecords");

            migrationBuilder.CreateTable(
                name: "OperationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationListId = table.Column<int>(type: "int", nullable: true),
                    Achivement = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Efficiency = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SAPNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationRecords_Warehouse_OperationLists_OperationListId",
                        column: x => x.OperationListId,
                        principalTable: "Warehouse_OperationLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationRecords_OperationListId",
                table: "OperationRecords",
                column: "OperationListId");
        }
    }
}
