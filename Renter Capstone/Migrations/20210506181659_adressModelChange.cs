using Microsoft.EntityFrameworkCore.Migrations;

namespace Renter_Capstone.Migrations
{
    public partial class adressModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Addresses_AddressId",
                table: "Listings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56c12422-2f13-4ec6-bd51-b26d91249d81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62ec4761-8047-46ec-812b-d75693f6aac6");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitute",
                table: "Addresses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Addresses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresses",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd0635ba-54b7-4482-b649-51fedbce59c2", "3a4809d6-486c-4e47-98b0-c71940e66e20", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b6c9685-18a3-46cf-8caf-bea174ce5e11", "bec39dff-7801-472e-b3ae-935ac09679a4", "Customer", "CUSTOMER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Addresses_AddressId",
                table: "Listings",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Addresses_AddressId",
                table: "Listings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6c9685-18a3-46cf-8caf-bea174ce5e11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0635ba-54b7-4482-b649-51fedbce59c2");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Latitute",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Listings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62ec4761-8047-46ec-812b-d75693f6aac6", "39d9ad7b-c1f6-4b2c-a8ac-6330f3910828", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56c12422-2f13-4ec6-bd51-b26d91249d81", "344b7151-5d4e-4bda-a005-28f9b4a0b685", "Customer", "CUSTOMER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Addresses_AddressId",
                table: "Listings",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
