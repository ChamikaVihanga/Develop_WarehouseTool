using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class minpr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_workFlowUsers_apd_approvalRequests_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers");

            migrationBuilder.DropIndex(
                name: "IX_apd_workFlowUsers_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers");

            migrationBuilder.DropColumn(
                name: "ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "apd_workFlowLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalDocumentId",
                table: "apd_approvalRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestDestinationsWorkFlowUsers",
                columns: table => new
                {
                    RequestDestinationsRequestDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowUsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDestinationsWorkFlowUsers", x => new { x.RequestDestinationsRequestDestinationId, x.WorkFlowUsersUserId });
                    table.ForeignKey(
                        name: "FK_RequestDestinationsWorkFlowUsers_apd_requestDestinations_RequestDestinationsRequestDestinationId",
                        column: x => x.RequestDestinationsRequestDestinationId,
                        principalTable: "apd_requestDestinations",
                        principalColumn: "RequestDestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestDestinationsWorkFlowUsers_apd_workFlowUsers_WorkFlowUsersUserId",
                        column: x => x.WorkFlowUsersUserId,
                        principalTable: "apd_workFlowUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalRequests_ApprovalDocumentId",
                table: "apd_approvalRequests",
                column: "ApprovalDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDestinationsWorkFlowUsers_WorkFlowUsersUserId",
                table: "RequestDestinationsWorkFlowUsers",
                column: "WorkFlowUsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_approvalRequests_apd_approvalDocuments_ApprovalDocumentId",
                table: "apd_approvalRequests",
                column: "ApprovalDocumentId",
                principalTable: "apd_approvalDocuments",
                principalColumn: "ApprovalDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalRequests_apd_approvalDocuments_ApprovalDocumentId",
                table: "apd_approvalRequests");

            migrationBuilder.DropTable(
                name: "RequestDestinationsWorkFlowUsers");

            migrationBuilder.DropIndex(
                name: "IX_apd_approvalRequests_ApprovalDocumentId",
                table: "apd_approvalRequests");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "apd_workFlowLogs");

            migrationBuilder.DropColumn(
                name: "ApprovalDocumentId",
                table: "apd_approvalRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowUsers_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers",
                column: "ApprovalRequestsApprovalRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_workFlowUsers_apd_approvalRequests_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers",
                column: "ApprovalRequestsApprovalRequestId",
                principalTable: "apd_approvalRequests",
                principalColumn: "ApprovalRequestId");
        }
    }
}
