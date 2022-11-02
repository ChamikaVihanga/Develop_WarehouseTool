using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class testMOve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationRecords_OperationLists_OperationListId",
                table: "OperationRecords");

            migrationBuilder.AlterColumn<int>(
                name: "OperationListId",
                table: "OperationRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationRecords_OperationLists_OperationListId",
                table: "OperationRecords",
                column: "OperationListId",
                principalTable: "OperationLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationRecords_OperationLists_OperationListId",
                table: "OperationRecords");

            migrationBuilder.AlterColumn<int>(
                name: "OperationListId",
                table: "OperationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationRecords_OperationLists_OperationListId",
                table: "OperationRecords",
                column: "OperationListId",
                principalTable: "OperationLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
