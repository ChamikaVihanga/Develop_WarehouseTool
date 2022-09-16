using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Relationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationalUnitId",
                table: "SapEmployee");

            migrationBuilder.RenameColumn(
                name: "PlantInfoId",
                table: "SapEmployee",
                newName: "SapWorkContractId");

            migrationBuilder.AddColumn<Guid>(
                name: "SapOrganizationalUnitId",
                table: "SapEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SapPlantId",
                table: "SapEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapOrganizationalUnitId",
                table: "SapEmployee",
                column: "SapOrganizationalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapPlantId",
                table: "SapEmployee",
                column: "SapPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapWorkContractId",
                table: "SapEmployee",
                column: "SapWorkContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_SapEmployee_SapOrganizationalUnits_SapOrganizationalUnitId",
                table: "SapEmployee",
                column: "SapOrganizationalUnitId",
                principalTable: "SapOrganizationalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SapEmployee_SapPlants_SapPlantId",
                table: "SapEmployee",
                column: "SapPlantId",
                principalTable: "SapPlants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SapEmployee_SapWorkContracts_SapWorkContractId",
                table: "SapEmployee",
                column: "SapWorkContractId",
                principalTable: "SapWorkContracts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SapEmployee_SapOrganizationalUnits_SapOrganizationalUnitId",
                table: "SapEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_SapEmployee_SapPlants_SapPlantId",
                table: "SapEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_SapEmployee_SapWorkContracts_SapWorkContractId",
                table: "SapEmployee");

            migrationBuilder.DropIndex(
                name: "IX_SapEmployee_SapOrganizationalUnitId",
                table: "SapEmployee");

            migrationBuilder.DropIndex(
                name: "IX_SapEmployee_SapPlantId",
                table: "SapEmployee");

            migrationBuilder.DropIndex(
                name: "IX_SapEmployee_SapWorkContractId",
                table: "SapEmployee");

            migrationBuilder.DropColumn(
                name: "SapOrganizationalUnitId",
                table: "SapEmployee");

            migrationBuilder.DropColumn(
                name: "SapPlantId",
                table: "SapEmployee");

            migrationBuilder.RenameColumn(
                name: "SapWorkContractId",
                table: "SapEmployee",
                newName: "PlantInfoId");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationalUnitId",
                table: "SapEmployee",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
