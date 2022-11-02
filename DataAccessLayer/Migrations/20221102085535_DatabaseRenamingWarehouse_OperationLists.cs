using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class DatabaseRenamingWarehouse_OperationLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationDetails_OperationLists_OperationListId",
                table: "OperationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationRecords_OperationLists_OperationListId",
                table: "OperationRecords");

            migrationBuilder.DropTable(
                name: "OperationLists");

            migrationBuilder.CreateTable(
                name: "Warehouse_OperationLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse_OperationLists", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OperationDetails_Warehouse_OperationLists_OperationListId",
                table: "OperationDetails",
                column: "OperationListId",
                principalTable: "Warehouse_OperationLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationRecords_Warehouse_OperationLists_OperationListId",
                table: "OperationRecords",
                column: "OperationListId",
                principalTable: "Warehouse_OperationLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationDetails_Warehouse_OperationLists_OperationListId",
                table: "OperationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationRecords_Warehouse_OperationLists_OperationListId",
                table: "OperationRecords");

            migrationBuilder.DropTable(
                name: "Warehouse_OperationLists");

            migrationBuilder.CreateTable(
                name: "OperationLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationLists", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OperationDetails_OperationLists_OperationListId",
                table: "OperationDetails",
                column: "OperationListId",
                principalTable: "OperationLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationRecords_OperationLists_OperationListId",
                table: "OperationRecords",
                column: "OperationListId",
                principalTable: "OperationLists",
                principalColumn: "Id");
        }
    }
}
