using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class logs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "apd_approvalRequests",
                columns: table => new
                {
                    ApprovalRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_approvalRequests", x => x.ApprovalRequestId);
                    table.ForeignKey(
                        name: "FK_apd_approvalRequests_apd_workFlowUsers_WorkFlowUserId",
                        column: x => x.WorkFlowUserId,
                        principalTable: "apd_workFlowUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "apd_workFlowLogs",
                columns: table => new
                {
                    WorkFlowLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovalRequestsApprovalRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_workFlowLogs", x => x.WorkFlowLogId);
                    table.ForeignKey(
                        name: "FK_apd_workFlowLogs_apd_approvalRequests_ApprovalRequestsApprovalRequestId",
                        column: x => x.ApprovalRequestsApprovalRequestId,
                        principalTable: "apd_approvalRequests",
                        principalColumn: "ApprovalRequestId");
                });

            migrationBuilder.CreateTable(
                name: "apd_requestDestinations",
                columns: table => new
                {
                    RequestDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_requestDestinations", x => x.RequestDestinationId);
                    table.ForeignKey(
                        name: "FK_apd_requestDestinations_apd_workFlowLogs_WorkFlowLogId",
                        column: x => x.WorkFlowLogId,
                        principalTable: "apd_workFlowLogs",
                        principalColumn: "WorkFlowLogId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowUsers_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers",
                column: "ApprovalRequestsApprovalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalRequests_WorkFlowUserId",
                table: "apd_approvalRequests",
                column: "WorkFlowUserId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_requestDestinations_WorkFlowLogId",
                table: "apd_requestDestinations",
                column: "WorkFlowLogId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowLogs_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowLogs",
                column: "ApprovalRequestsApprovalRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_workFlowUsers_apd_approvalRequests_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers",
                column: "ApprovalRequestsApprovalRequestId",
                principalTable: "apd_approvalRequests",
                principalColumn: "ApprovalRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_workFlowUsers_apd_approvalRequests_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers");

            migrationBuilder.DropTable(
                name: "apd_requestDestinations");

            migrationBuilder.DropTable(
                name: "apd_workFlowLogs");

            migrationBuilder.DropTable(
                name: "apd_approvalRequests");

            migrationBuilder.DropIndex(
                name: "IX_apd_workFlowUsers_ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers");

            migrationBuilder.DropColumn(
                name: "ApprovalRequestsApprovalRequestId",
                table: "apd_workFlowUsers");
        }
    }
}
