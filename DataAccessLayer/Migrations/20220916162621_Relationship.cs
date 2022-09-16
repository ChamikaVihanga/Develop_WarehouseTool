using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SapPlantId",
                table: "SapCostCenters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SapOrganizationalUnits_SapCostCenterId",
                table: "SapOrganizationalUnits",
                column: "SapCostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SapCostCenters_SapPlantId",
                table: "SapCostCenters",
                column: "SapPlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SapCostCenters_SapPlants_SapPlantId",
                table: "SapCostCenters",
                column: "SapPlantId",
                principalTable: "SapPlants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SapOrganizationalUnits_SapCostCenters_SapCostCenterId",
                table: "SapOrganizationalUnits",
                column: "SapCostCenterId",
                principalTable: "SapCostCenters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SapCostCenters_SapPlants_SapPlantId",
                table: "SapCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_SapOrganizationalUnits_SapCostCenters_SapCostCenterId",
                table: "SapOrganizationalUnits");

            migrationBuilder.DropIndex(
                name: "IX_SapOrganizationalUnits_SapCostCenterId",
                table: "SapOrganizationalUnits");

            migrationBuilder.DropIndex(
                name: "IX_SapCostCenters_SapPlantId",
                table: "SapCostCenters");

            migrationBuilder.DropColumn(
                name: "SapPlantId",
                table: "SapCostCenters");
        }
    }
}
