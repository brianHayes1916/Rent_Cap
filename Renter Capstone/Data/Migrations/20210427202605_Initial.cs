using Microsoft.EntityFrameworkCore.Migrations;

namespace Renter_Capstone.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50ae59f5-00ff-4715-8df3-50c567eced3b", "abccd16e-b237-4654-b77c-c5b1fc7a8a5c", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50ae59f5-00ff-4715-8df3-50c567eced3b");
        }
    }
}
