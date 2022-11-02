using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class logs3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "apd_workFlowLogs");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkFlowIndexId",
                table: "apd_workFlowLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowLogs_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs",
                column: "WorkFlowIndexeWorkFlowIndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_workFlowLogs_apd_workFlowIndexes_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs",
                column: "WorkFlowIndexeWorkFlowIndexId",
                principalTable: "apd_workFlowIndexes",
                principalColumn: "WorkFlowIndexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_workFlowLogs_apd_workFlowIndexes_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropIndex(
                name: "IX_apd_workFlowLogs_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropColumn(
                name: "WorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropColumn(
                name: "WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "apd_workFlowLogs",
                type: "int",
                nullable: true);
        }
    }
}
