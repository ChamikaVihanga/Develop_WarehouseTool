using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class prorityIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriorityIndexes",
                columns: table => new
                {
                    PriorityIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriorityIndex = table.Column<int>(type: "int", nullable: true),
                    ApprovalDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityIndexes", x => x.PriorityIndexId);
                    table.ForeignKey(
                        name: "FK_PriorityIndexes_apd_approvalDefinitions_ApprovalDefinitionId",
                        column: x => x.ApprovalDefinitionId,
                        principalTable: "apd_approvalDefinitions",
                        principalColumn: "ApprovalDefinitionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriorityIndexes_ApprovalDefinitionId",
                table: "PriorityIndexes",
                column: "ApprovalDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriorityIndexes");
        }
    }
}
