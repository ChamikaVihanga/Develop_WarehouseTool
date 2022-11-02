using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class prorityIndexes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriorityIndexes_apd_approvalDefinitions_ApprovalDefinitionId",
                table: "PriorityIndexes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriorityIndexes",
                table: "PriorityIndexes");

            migrationBuilder.RenameTable(
                name: "PriorityIndexes",
                newName: "apd_priorityIndexes");

            migrationBuilder.RenameIndex(
                name: "IX_PriorityIndexes_ApprovalDefinitionId",
                table: "apd_priorityIndexes",
                newName: "IX_apd_priorityIndexes_ApprovalDefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_apd_priorityIndexes",
                table: "apd_priorityIndexes",
                column: "PriorityIndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_priorityIndexes_apd_approvalDefinitions_ApprovalDefinitionId",
                table: "apd_priorityIndexes",
                column: "ApprovalDefinitionId",
                principalTable: "apd_approvalDefinitions",
                principalColumn: "ApprovalDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_priorityIndexes_apd_approvalDefinitions_ApprovalDefinitionId",
                table: "apd_priorityIndexes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_apd_priorityIndexes",
                table: "apd_priorityIndexes");

            migrationBuilder.RenameTable(
                name: "apd_priorityIndexes",
                newName: "PriorityIndexes");

            migrationBuilder.RenameIndex(
                name: "IX_apd_priorityIndexes_ApprovalDefinitionId",
                table: "PriorityIndexes",
                newName: "IX_PriorityIndexes_ApprovalDefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriorityIndexes",
                table: "PriorityIndexes",
                column: "PriorityIndexId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriorityIndexes_apd_approvalDefinitions_ApprovalDefinitionId",
                table: "PriorityIndexes",
                column: "ApprovalDefinitionId",
                principalTable: "apd_approvalDefinitions",
                principalColumn: "ApprovalDefinitionId");
        }
    }
}
