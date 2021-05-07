using Microsoft.EntityFrameworkCore.Migrations;

namespace Renter_Capstone.Migrations
{
    public partial class ModelChangesForpotential : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42821090-e1f3-4cdc-8a4f-32d98a7604bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f1c69b5-5f58-4786-9080-579b3a1684cf");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Customers",
                newName: "Year");

            migrationBuilder.AddColumn<int>(
                name: "YearPref",
                table: "Listings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "217d6b46-3d5a-4dc9-bbbb-bd2a56572b0e", "d0838054-2789-484b-b215-6e1f9da43773", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f9ad637-e65f-4656-95ce-fe1e606025fe", "12f8399a-ae9c-491d-8150-07d6e90e61cb", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "217d6b46-3d5a-4dc9-bbbb-bd2a56572b0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f9ad637-e65f-4656-95ce-fe1e606025fe");

            migrationBuilder.DropColumn(
                name: "YearPref",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Customers",
                newName: "year");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f1c69b5-5f58-4786-9080-579b3a1684cf", "78681ce6-107f-423e-bc5a-cc70d0f0fe63", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "42821090-e1f3-4cdc-8a4f-32d98a7604bc", "6fa89cec-519e-4cf2-89e0-9667abf14b7e", "Customer", "CUSTOMER" });
        }
    }
}
