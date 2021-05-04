using Microsoft.EntityFrameworkCore.Migrations;

namespace Renter_Capstone.Migrations
{
    public partial class nullableListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Listings_ListingId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aebc221-84f6-4d74-b3fc-c9d3b739f625");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cba98e87-7026-4369-8da3-d540329dabc4");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62ec4761-8047-46ec-812b-d75693f6aac6", "39d9ad7b-c1f6-4b2c-a8ac-6330f3910828", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56c12422-2f13-4ec6-bd51-b26d91249d81", "344b7151-5d4e-4bda-a005-28f9b4a0b685", "Customer", "CUSTOMER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Listings_ListingId",
                table: "Customers",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "ListingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Listings_ListingId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56c12422-2f13-4ec6-bd51-b26d91249d81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62ec4761-8047-46ec-812b-d75693f6aac6");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cba98e87-7026-4369-8da3-d540329dabc4", "1aea7d88-99e1-4725-82b5-b2f30fb41d0f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8aebc221-84f6-4d74-b3fc-c9d3b739f625", "56d61389-e5b3-4a27-8c09-64292d628b26", "Customer", "CUSTOMER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Listings_ListingId",
                table: "Customers",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "ListingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
