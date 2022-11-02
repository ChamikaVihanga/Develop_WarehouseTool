using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class approavlrequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ap_approvalRequests",
                columns: table => new
                {
                    ApprovalRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    approvalPathUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    registeredDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPending = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_approvalRequests", x => x.ApprovalRequestId);
                    table.ForeignKey(
                        name: "FK_ap_approvalRequests_ap_approvalPathUsers_approvalPathUserId",
                        column: x => x.approvalPathUserId,
                        principalTable: "ap_approvalPathUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ap_approvalRequests_ap_registeredDocuments_registeredDocumentId",
                        column: x => x.registeredDocumentId,
                        principalTable: "ap_registeredDocuments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ap_approvalRequests_approvalPathUserId",
                table: "ap_approvalRequests",
                column: "approvalPathUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_approvalRequests_registeredDocumentId",
                table: "ap_approvalRequests",
                column: "registeredDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ap_approvalRequests");
        }
    }
}
