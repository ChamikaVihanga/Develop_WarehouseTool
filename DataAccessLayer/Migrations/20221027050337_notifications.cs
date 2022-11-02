using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class notifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalUserNotificationId",
                table: "apd_approvalDestinations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApprovalUserNotification",
                columns: table => new
                {
                    NotifyUserSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalUserNotification", x => x.NotifyUserSetId);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalUserNotificationWorkFlowUsers",
                columns: table => new
                {
                    ApprovalUserNotificationsNotifyUserSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowUsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalUserNotificationWorkFlowUsers", x => new { x.ApprovalUserNotificationsNotifyUserSetId, x.WorkFlowUsersUserId });
                    table.ForeignKey(
                        name: "FK_ApprovalUserNotificationWorkFlowUsers_apd_workFlowUsers_WorkFlowUsersUserId",
                        column: x => x.WorkFlowUsersUserId,
                        principalTable: "apd_workFlowUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalUserNotificationWorkFlowUsers_ApprovalUserNotification_ApprovalUserNotificationsNotifyUserSetId",
                        column: x => x.ApprovalUserNotificationsNotifyUserSetId,
                        principalTable: "ApprovalUserNotification",
                        principalColumn: "NotifyUserSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalDestinations_ApprovalUserNotificationId",
                table: "apd_approvalDestinations",
                column: "ApprovalUserNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalDefinitions_ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions",
                column: "ApprovalUserNotificationNotifyUserSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalUserNotificationWorkFlowUsers_WorkFlowUsersUserId",
                table: "ApprovalUserNotificationWorkFlowUsers",
                column: "WorkFlowUsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_approvalDefinitions_ApprovalUserNotification_ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions",
                column: "ApprovalUserNotificationNotifyUserSetId",
                principalTable: "ApprovalUserNotification",
                principalColumn: "NotifyUserSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_approvalDestinations_ApprovalUserNotification_ApprovalUserNotificationId",
                table: "apd_approvalDestinations",
                column: "ApprovalUserNotificationId",
                principalTable: "ApprovalUserNotification",
                principalColumn: "NotifyUserSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDefinitions_ApprovalUserNotification_ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDestinations_ApprovalUserNotification_ApprovalUserNotificationId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropTable(
                name: "ApprovalUserNotificationWorkFlowUsers");

            migrationBuilder.DropTable(
                name: "ApprovalUserNotification");

            migrationBuilder.DropIndex(
                name: "IX_apd_approvalDestinations_ApprovalUserNotificationId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropIndex(
                name: "IX_apd_approvalDefinitions_ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions");

            migrationBuilder.DropColumn(
                name: "ApprovalUserNotificationId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropColumn(
                name: "ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions");
        }
    }
}
