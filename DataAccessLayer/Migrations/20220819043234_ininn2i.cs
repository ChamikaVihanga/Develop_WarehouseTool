using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ininn2i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.AlterColumn<int>(
                name: "AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodId",
                principalTable: "AuthenticationHttpMethods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements");

            migrationBuilder.AlterColumn<int>(
                name: "AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodId",
                principalTable: "AuthenticationHttpMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
