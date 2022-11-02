using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class apdinit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalConfigurationsApprovalDestinations_apd_approvalDestinations_ApprovalDestinationsApprovalDestination",
                table: "ApprovalConfigurationsApprovalDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalDestinationsWorkFlowUsers_apd_approvalDestinations_ApprovalDestinationsApprovalDestination",
                table: "ApprovalDestinationsWorkFlowUsers");

            migrationBuilder.RenameColumn(
                name: "ApprovalDestinationsApprovalDestination",
                table: "ApprovalDestinationsWorkFlowUsers",
                newName: "ApprovalDestinationsApprovalDestinationId");

            migrationBuilder.RenameColumn(
                name: "ApprovalDestinationsApprovalDestination",
                table: "ApprovalConfigurationsApprovalDestinations",
                newName: "ApprovalDestinationsApprovalDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalConfigurationsApprovalDestinations_ApprovalDestinationsApprovalDestination",
                table: "ApprovalConfigurationsApprovalDestinations",
                newName: "IX_ApprovalConfigurationsApprovalDestinations_ApprovalDestinationsApprovalDestinationId");

            migrationBuilder.RenameColumn(
                name: "ApprovalDestination",
                table: "apd_approvalDestinations",
                newName: "ApprovalDestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalConfigurationsApprovalDestinations_apd_approvalDestinations_ApprovalDestinationsApprovalDestinationId",
                table: "ApprovalConfigurationsApprovalDestinations",
                column: "ApprovalDestinationsApprovalDestinationId",
                principalTable: "apd_approvalDestinations",
                principalColumn: "ApprovalDestinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalDestinationsWorkFlowUsers_apd_approvalDestinations_ApprovalDestinationsApprovalDestinationId",
                table: "ApprovalDestinationsWorkFlowUsers",
                column: "ApprovalDestinationsApprovalDestinationId",
                principalTable: "apd_approvalDestinations",
                principalColumn: "ApprovalDestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalConfigurationsApprovalDestinations_apd_approvalDestinations_ApprovalDestinationsApprovalDestinationId",
                table: "ApprovalConfigurationsApprovalDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalDestinationsWorkFlowUsers_apd_approvalDestinations_ApprovalDestinationsApprovalDestinationId",
                table: "ApprovalDestinationsWorkFlowUsers");

            migrationBuilder.RenameColumn(
                name: "ApprovalDestinationsApprovalDestinationId",
                table: "ApprovalDestinationsWorkFlowUsers",
                newName: "ApprovalDestinationsApprovalDestination");

            migrationBuilder.RenameColumn(
                name: "ApprovalDestinationsApprovalDestinationId",
                table: "ApprovalConfigurationsApprovalDestinations",
                newName: "ApprovalDestinationsApprovalDestination");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalConfigurationsApprovalDestinations_ApprovalDestinationsApprovalDestinationId",
                table: "ApprovalConfigurationsApprovalDestinations",
                newName: "IX_ApprovalConfigurationsApprovalDestinations_ApprovalDestinationsApprovalDestination");

            migrationBuilder.RenameColumn(
                name: "ApprovalDestinationId",
                table: "apd_approvalDestinations",
                newName: "ApprovalDestination");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalConfigurationsApprovalDestinations_apd_approvalDestinations_ApprovalDestinationsApprovalDestination",
                table: "ApprovalConfigurationsApprovalDestinations",
                column: "ApprovalDestinationsApprovalDestination",
                principalTable: "apd_approvalDestinations",
                principalColumn: "ApprovalDestination",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalDestinationsWorkFlowUsers_apd_approvalDestinations_ApprovalDestinationsApprovalDestination",
                table: "ApprovalDestinationsWorkFlowUsers",
                column: "ApprovalDestinationsApprovalDestination",
                principalTable: "apd_approvalDestinations",
                principalColumn: "ApprovalDestination",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
