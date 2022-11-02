using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class apdinit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDestinations_apd_workFlowIndexes_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropIndex(
                name: "IX_apd_approvalDestinations_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropColumn(
                name: "WorkFlowIndexeWorkFlowIndexId",
                table: "apd_approvalDestinations");

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalDestinations_WorkFlowIndexId",
                table: "apd_approvalDestinations",
                column: "WorkFlowIndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_approvalDestinations_apd_workFlowIndexes_WorkFlowIndexId",
                table: "apd_approvalDestinations",
                column: "WorkFlowIndexId",
                principalTable: "apd_workFlowIndexes",
                principalColumn: "WorkFlowIndexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDestinations_apd_workFlowIndexes_WorkFlowIndexId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropIndex(
                name: "IX_apd_approvalDestinations_WorkFlowIndexId",
                table: "apd_approvalDestinations");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkFlowIndexeWorkFlowIndexId",
                table: "apd_approvalDestinations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalDestinations_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_approvalDestinations",
                column: "WorkFlowIndexeWorkFlowIndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_approvalDestinations_apd_workFlowIndexes_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_approvalDestinations",
                column: "WorkFlowIndexeWorkFlowIndexId",
                principalTable: "apd_workFlowIndexes",
                principalColumn: "WorkFlowIndexId");
        }
    }
}
