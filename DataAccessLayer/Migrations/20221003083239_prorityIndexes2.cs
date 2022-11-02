using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class prorityIndexes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalDocumentId",
                table: "apd_priorityIndexes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_apd_priorityIndexes_ApprovalDocumentId",
                table: "apd_priorityIndexes",
                column: "ApprovalDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_apd_priorityIndexes_apd_approvalDocuments_ApprovalDocumentId",
                table: "apd_priorityIndexes",
                column: "ApprovalDocumentId",
                principalTable: "apd_approvalDocuments",
                principalColumn: "ApprovalDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apd_priorityIndexes_apd_approvalDocuments_ApprovalDocumentId",
                table: "apd_priorityIndexes");

            migrationBuilder.DropIndex(
                name: "IX_apd_priorityIndexes_ApprovalDocumentId",
                table: "apd_priorityIndexes");

            migrationBuilder.DropColumn(
                name: "ApprovalDocumentId",
                table: "apd_priorityIndexes");
        }
    }
}
