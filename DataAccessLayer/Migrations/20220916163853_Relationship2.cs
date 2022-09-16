using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Relationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SapEmployee_SapWorkContracts_SapWorkContractId",
                table: "SapEmployee");

            migrationBuilder.AlterColumn<Guid>(
                name: "SapWorkContractId",
                table: "SapEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SapEmployee_SapWorkContracts_SapWorkContractId",
                table: "SapEmployee",
                column: "SapWorkContractId",
                principalTable: "SapWorkContracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SapEmployee_SapWorkContracts_SapWorkContractId",
                table: "SapEmployee");

            migrationBuilder.AlterColumn<Guid>(
                name: "SapWorkContractId",
                table: "SapEmployee",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SapEmployee_SapWorkContracts_SapWorkContractId",
                table: "SapEmployee",
                column: "SapWorkContractId",
                principalTable: "SapWorkContracts",
                principalColumn: "Id");
        }
    }
}
