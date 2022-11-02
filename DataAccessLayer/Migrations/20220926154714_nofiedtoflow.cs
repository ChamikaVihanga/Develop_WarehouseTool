using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class nofiedtoflow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalPathUsersUserSetsToNotify");

            migrationBuilder.AddColumn<Guid>(
                name: "notifiedUserSetsId",
                table: "ap_approvalFlowOrder",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApprovalPathUsersNotifiedUserSets",
                columns: table => new
                {
                    approvalPathUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userSetsToNotifiyNotifyUserSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalPathUsersNotifiedUserSets", x => new { x.approvalPathUsersId, x.userSetsToNotifiyNotifyUserSetId });
                    table.ForeignKey(
                        name: "FK_ApprovalPathUsersNotifiedUserSets_ap_approvalPathUsers_approvalPathUsersId",
                        column: x => x.approvalPathUsersId,
                        principalTable: "ap_approvalPathUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalPathUsersNotifiedUserSets_ap_userSetsToNotify_userSetsToNotifiyNotifyUserSetId",
                        column: x => x.userSetsToNotifiyNotifyUserSetId,
                        principalTable: "ap_userSetsToNotify",
                        principalColumn: "NotifyUserSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ap_approvalFlowOrder_notifiedUserSetsId",
                table: "ap_approvalFlowOrder",
                column: "notifiedUserSetsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalPathUsersNotifiedUserSets_userSetsToNotifiyNotifyUserSetId",
                table: "ApprovalPathUsersNotifiedUserSets",
                column: "userSetsToNotifiyNotifyUserSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ap_approvalFlowOrder_ap_userSetsToNotify_notifiedUserSetsId",
                table: "ap_approvalFlowOrder",
                column: "notifiedUserSetsId",
                principalTable: "ap_userSetsToNotify",
                principalColumn: "NotifyUserSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ap_approvalFlowOrder_ap_userSetsToNotify_notifiedUserSetsId",
                table: "ap_approvalFlowOrder");

            migrationBuilder.DropTable(
                name: "ApprovalPathUsersNotifiedUserSets");

            migrationBuilder.DropIndex(
                name: "IX_ap_approvalFlowOrder_notifiedUserSetsId",
                table: "ap_approvalFlowOrder");

            migrationBuilder.DropColumn(
                name: "notifiedUserSetsId",
                table: "ap_approvalFlowOrder");

            migrationBuilder.CreateTable(
                name: "ApprovalPathUsersUserSetsToNotify",
                columns: table => new
                {
                    approvalPathUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userSetsToNotifiyNotifyUserSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalPathUsersUserSetsToNotify", x => new { x.approvalPathUsersId, x.userSetsToNotifiyNotifyUserSetId });
                    table.ForeignKey(
                        name: "FK_ApprovalPathUsersUserSetsToNotify_ap_approvalPathUsers_approvalPathUsersId",
                        column: x => x.approvalPathUsersId,
                        principalTable: "ap_approvalPathUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalPathUsersUserSetsToNotify_ap_userSetsToNotify_userSetsToNotifiyNotifyUserSetId",
                        column: x => x.userSetsToNotifiyNotifyUserSetId,
                        principalTable: "ap_userSetsToNotify",
                        principalColumn: "NotifyUserSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalPathUsersUserSetsToNotify_userSetsToNotifiyNotifyUserSetId",
                table: "ApprovalPathUsersUserSetsToNotify",
                column: "userSetsToNotifiyNotifyUserSetId");
        }
    }
}
