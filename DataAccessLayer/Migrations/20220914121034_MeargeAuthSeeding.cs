using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class MeargeAuthSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthenticationHttpMethods",
                columns: new[] { "Id", "HttpMethod" },
                values: new object[,]
                {
                    { 1, "GET" },
                    { 2, "POST" },
                    { 3, "PUT" },
                    { 4, "DELETE" },
                    { 5, "PATCH" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthenticationHttpMethods",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
