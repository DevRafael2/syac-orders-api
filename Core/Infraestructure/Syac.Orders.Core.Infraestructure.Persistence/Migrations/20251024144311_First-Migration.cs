using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Syac.Orders.Core.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "Orders");

            migrationBuilder.EnsureSchema(
                name: "Stock");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWSEQUENTIALID()", comment: "Id del registro"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Nombre del cliente"),
                    Email = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false, comment: "Correo del usuario"),
                    IdentityNumber = table.Column<long>(type: "bigint", nullable: false, comment: "Numero de identificación del usuario"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indica si el registro ha sido eliminado")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Stock",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false, comment: "Id del registro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Nombre del producto"),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false, comment: "Precio del producto"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indica si el registro ha sido eliminado")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWSEQUENTIALID()", comment: "Id del registro"),
                    CustomerId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, comment: "Id del cliente"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Indica la fecha y hora en que se creo el pedido"),
                    State = table.Column<bool>(type: "bit", nullable: true, comment: "Indica el estado del pedido, siendo null para en proceso, false para cancelado y true confirmado"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indica si el registro ha sido eliminado")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Users",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id del registro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<short>(type: "smallint", nullable: false, comment: "Id del producto relacionado"),
                    OrderId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, comment: "Id de la orden"),
                    Amount = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1, comment: "Cantidad solicitada del producto"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indica si el registro ha sido eliminado")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Orders",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Stock",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Stock",
                table: "Products",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { (short)1, false, "Teclado mecánico", 400m },
                    { (short)2, false, "Mouse ergonómico", 150m },
                    { (short)3, false, "Pantalla 27 pulgadas", 1200m },
                    { (short)4, false, "Cable HDMI", 20m },
                    { (short)5, false, "Silla gamer", 600m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId_ProductId",
                schema: "Orders",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                schema: "Orders",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Orders",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Users");
        }
    }
}
