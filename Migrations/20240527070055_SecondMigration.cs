using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CS5227_A1_ABDUL36302.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ff87007-b0af-4ccf-a3eb-3fe52f048ddf", null, "client", "client" },
                    { "6d8a2afe-3d6e-4a16-9f14-ead6e15ba741", null, "admin", "admin" },
                    { "8e07bcac-5fec-4e57-82f2-93544cc69412", null, "seller", "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ff87007-b0af-4ccf-a3eb-3fe52f048ddf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d8a2afe-3d6e-4a16-9f14-ead6e15ba741");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e07bcac-5fec-4e57-82f2-93544cc69412");
        }
    }
}
