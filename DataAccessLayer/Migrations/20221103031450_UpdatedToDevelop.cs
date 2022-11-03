using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdatedToDevelop : Migration
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
                name: "apd_approvalUserNotification",
                columns: table => new
                {
                    NotifyUserSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_approvalUserNotification", x => x.NotifyUserSetId);
                });

            migrationBuilder.CreateTable(
                name: "Workspace_OrganizationalUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspace_OrganizationalUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workspace_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WsOrganizationalUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspace_Users", x => x.Id);
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
                        name: "FK_ApprovalUserNotificationWorkFlowUsers_apd_approvalUserNotification_ApprovalUserNotificationsNotifyUserSetId",
                        column: x => x.ApprovalUserNotificationsNotifyUserSetId,
                        principalTable: "apd_approvalUserNotification",
                        principalColumn: "NotifyUserSetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalUserNotificationWorkFlowUsers_apd_workFlowUsers_WorkFlowUsersUserId",
                        column: x => x.WorkFlowUsersUserId,
                        principalTable: "apd_workFlowUsers",
                        principalColumn: "UserId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDefinitions_apd_approvalUserNotification_ApprovalUserNotificationNotifyUserSetId",
                table: "apd_approvalDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_apd_approvalDestinations_apd_approvalUserNotification_ApprovalUserNotificationId",
                table: "apd_approvalDestinations");

            migrationBuilder.DropTable(
                name: "ApprovalUserNotificationWorkFlowUsers");

            migrationBuilder.DropTable(
                name: "Workspace_OrganizationalUnits");

            migrationBuilder.DropTable(
                name: "Workspace_Users");

            migrationBuilder.DropTable(
                name: "apd_approvalUserNotification");

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
