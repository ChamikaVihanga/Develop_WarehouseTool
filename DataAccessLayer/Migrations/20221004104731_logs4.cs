using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class logs4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_workFlowLogs_apd_approvalRequests_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_apd_workFlowLogs_apd_workFlowIndexes_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropIndex(
                name: "IX_apd_workFlowLogs_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropIndex(
                name: "IX_apd_workFlowLogs_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropColumn(
                name: "ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropColumn(
                name: "WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowLogs_ApprovalRequestId",
                table: "apd_workFlowLogs",
                column: "ApprovalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowLogs_WorkFlowIndexId",
                table: "apd_workFlowLogs",
                column: "WorkFlowIndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_workFlowLogs_apd_approvalRequests_ApprovalRequestId",
                table: "apd_workFlowLogs",
                column: "ApprovalRequestId",
                principalTable: "apd_approvalRequests",
                principalColumn: "ApprovalRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_workFlowLogs_apd_workFlowIndexes_WorkFlowIndexId",
                table: "apd_workFlowLogs",
                column: "WorkFlowIndexId",
                principalTable: "apd_workFlowIndexes",
                principalColumn: "WorkFlowIndexId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_workFlowLogs_apd_approvalRequests_ApprovalRequestId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_apd_workFlowLogs_apd_workFlowIndexes_WorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropIndex(
                name: "IX_apd_workFlowLogs_ApprovalRequestId",
                table: "apd_workFlowLogs");

            migrationBuilder.DropIndex(
                name: "IX_apd_workFlowLogs_WorkFlowIndexId",
                table: "apd_workFlowLogs");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowLogs_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowLogs",
                column: "ApprovalRequestsApprovalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowLogs_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs",
                column: "WorkFlowIndexeWorkFlowIndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_workFlowLogs_apd_approvalRequests_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowLogs",
                column: "ApprovalRequestsApprovalRequestId",
                principalTable: "apd_approvalRequests",
                principalColumn: "ApprovalRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_workFlowLogs_apd_workFlowIndexes_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_workFlowLogs",
                column: "WorkFlowIndexeWorkFlowIndexId",
                principalTable: "apd_workFlowIndexes",
                principalColumn: "WorkFlowIndexId");
        }
    }
}
