using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class notifications2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDefinitions_ApprovalUserNotification_ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDestinations_ApprovalUserNotification_ApprovalUserNotificationId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalUserNotificationWorkFlowUsers_ApprovalUserNotification_ApprovalUserNotificationsNotifyUserSetId",
                table: "ApprovalUserNotificationWorkFlowUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalUserNotification",
                table: "ApprovalUserNotification");

            migrationBuilder.RenameTable(
                name: "ApprovalUserNotification",
                newName: "apd_approvalUserNotification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_apd_approvalUserNotification",
                table: "apd_approvalUserNotification",
                column: "NotifyUserSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_approvalDefinitions_apd_approvalUserNotification_ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions",
                column: "ApprovalUserNotificationNotifyUserSetId",
                principalTable: "apd_approvalUserNotification",
                principalColumn: "NotifyUserSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_approvalDestinations_apd_approvalUserNotification_ApprovalUserNotificationId",
                table: "apd_approvalDestinations",
                column: "ApprovalUserNotificationId",
                principalTable: "apd_approvalUserNotification",
                principalColumn: "NotifyUserSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalUserNotificationWorkFlowUsers_apd_approvalUserNotification_ApprovalUserNotificationsNotifyUserSetId",
                table: "ApprovalUserNotificationWorkFlowUsers",
                column: "ApprovalUserNotificationsNotifyUserSetId",
                principalTable: "apd_approvalUserNotification",
                principalColumn: "NotifyUserSetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDefinitions_apd_approvalUserNotification_ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDestinations_apd_approvalUserNotification_ApprovalUserNotificationId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalUserNotificationWorkFlowUsers_apd_approvalUserNotification_ApprovalUserNotificationsNotifyUserSetId",
                table: "ApprovalUserNotificationWorkFlowUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_apd_approvalUserNotification",
                table: "apd_approvalUserNotification");

            migrationBuilder.RenameTable(
                name: "apd_approvalUserNotification",
                newName: "ApprovalUserNotification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalUserNotification",
                table: "ApprovalUserNotification",
                column: "NotifyUserSetId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalUserNotificationWorkFlowUsers_ApprovalUserNotification_ApprovalUserNotificationsNotifyUserSetId",
                table: "ApprovalUserNotificationWorkFlowUsers",
                column: "ApprovalUserNotificationsNotifyUserSetId",
                principalTable: "ApprovalUserNotification",
                principalColumn: "NotifyUserSetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
