using Microsoft.EntityFrameworkCore.Migrations;

namespace Renter_Capstone.Migrations
{
    public partial class modelChangesForFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6c9685-18a3-46cf-8caf-bea174ce5e11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0635ba-54b7-4482-b649-51fedbce59c2");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Listings");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRoomMates",
                table: "Listings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f1c69b5-5f58-4786-9080-579b3a1684cf", "78681ce6-107f-423e-bc5a-cc70d0f0fe63", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "42821090-e1f3-4cdc-8a4f-32d98a7604bc", "6fa89cec-519e-4cf2-89e0-9667abf14b7e", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42821090-e1f3-4cdc-8a4f-32d98a7604bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f1c69b5-5f58-4786-9080-579b3a1684cf");

            migrationBuilder.DropColumn(
                name: "NumberOfRoomMates",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "year",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd0635ba-54b7-4482-b649-51fedbce59c2", "3a4809d6-486c-4e47-98b0-c71940e66e20", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b6c9685-18a3-46cf-8caf-bea174ce5e11", "bec39dff-7801-472e-b3ae-935ac09679a4", "Customer", "CUSTOMER" });
        }
    }
}
