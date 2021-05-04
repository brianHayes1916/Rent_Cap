using Microsoft.EntityFrameworkCore.Migrations;

namespace Renter_Capstone.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308efde5-e97d-4f23-b1ae-9fa674f4e760");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93508945-24f8-419b-aed0-bd04b982a68e");

            migrationBuilder.CreateTable(
                name: "InterestedParties",
                columns: table => new
                {
                    InterestedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestedParties", x => x.InterestedId);
                    table.ForeignKey(
                        name: "FK_InterestedParties_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestedParties_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06927ff5-4782-4f4d-b301-209f774521d4", "93f23bd7-006f-4ab3-94da-f9fdb405d436", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87948262-bcb8-4af7-9973-150e5bbe44d1", "5fe7667b-5134-4e3d-b9dc-8c410eafd8c1", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_InterestedParties_CustomerId",
                table: "InterestedParties",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestedParties_ListingId",
                table: "InterestedParties",
                column: "ListingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestedParties");

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
                values: new object[] { "93508945-24f8-419b-aed0-bd04b982a68e", "478aff0d-cc7e-4baa-a0bf-4c43559308b5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "308efde5-e97d-4f23-b1ae-9fa674f4e760", "089d0202-ed44-49b4-aaa5-e0d9db900d89", "Customer", "CUSTOMER" });
        }
    }
}
