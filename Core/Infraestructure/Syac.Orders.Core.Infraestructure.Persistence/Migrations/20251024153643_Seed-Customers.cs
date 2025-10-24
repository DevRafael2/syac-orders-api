using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Syac.Orders.Core.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Users",
                table: "Customers",
                columns: new[] { "Id", "Email", "IdentityNumber", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("1b4e28ba-2fa1-11d2-883f-0016d3cca427"), "rgcascante@outlook.com", 1005714857L, false, "Rafael Cascante" },
                    { new Guid("3fedd6a9-4fc4-4d65-9e73-7ab16e55f2b9"), "sara@gmail.com", 12345678L, false, "Sara Giraldo" },
                    { new Guid("b29c4c7f-ea5d-431f-bca6-e650742cfb9f"), "customer@syac.com", 12345678L, false, "Syac" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("1b4e28ba-2fa1-11d2-883f-0016d3cca427"));

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3fedd6a9-4fc4-4d65-9e73-7ab16e55f2b9"));

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b29c4c7f-ea5d-431f-bca6-e650742cfb9f"));
        }
    }
}
