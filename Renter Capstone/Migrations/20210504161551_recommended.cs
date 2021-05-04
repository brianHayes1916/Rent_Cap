using Microsoft.EntityFrameworkCore.Migrations;

namespace Renter_Capstone.Migrations
{
    public partial class recommended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06927ff5-4782-4f4d-b301-209f774521d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87948262-bcb8-4af7-9973-150e5bbe44d1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cba98e87-7026-4369-8da3-d540329dabc4", "1aea7d88-99e1-4725-82b5-b2f30fb41d0f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8aebc221-84f6-4d74-b3fc-c9d3b739f625", "56d61389-e5b3-4a27-8c09-64292d628b26", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aebc221-84f6-4d74-b3fc-c9d3b739f625");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cba98e87-7026-4369-8da3-d540329dabc4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06927ff5-4782-4f4d-b301-209f774521d4", "93f23bd7-006f-4ab3-94da-f9fdb405d436", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87948262-bcb8-4af7-9973-150e5bbe44d1", "5fe7667b-5134-4e3d-b9dc-8c410eafd8c1", "Customer", "CUSTOMER" });
        }
    }
}
