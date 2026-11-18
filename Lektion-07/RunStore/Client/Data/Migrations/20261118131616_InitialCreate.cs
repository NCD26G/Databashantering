using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    supplierName = table.Column<string>(type: "VARCHAR(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR(2048)", nullable: true),
                    imageUrl = table.Column<string>(type: "VARCHAR(128)", nullable: true),
                    itemNumber = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    productName = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.CheckConstraint("CK_Product_Price_NonNegative", "price >= 0");
                    table.ForeignKey(
                        name: "FK_products_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "suppliers",
                columns: new[] { "id", "supplierName" },
                values: new object[,]
                {
                    { 1, "Asics" },
                    { 2, "Nike" },
                    { 3, "CLN Athletics" },
                    { 4, "Swix" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "description", "imageUrl", "itemNumber", "productName", "price", "SupplierId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet", "https://res.cloudinary.com/softtech-dev/image/upload/v1786556514/shoe-1_qig4ut.jpg", "1000", "Core 2000", 1295m, 1 },
                    { 2, "Lorem ipsum dolor sit amet", "https://res.cloudinary.com/softtech-dev/image/upload/v1786556530/shoe-3_qbzcwy.jpg", "1001", "Gel 27", 2295m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_itemNumber",
                table: "products",
                column: "itemNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_SupplierId",
                table: "products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_supplierName",
                table: "suppliers",
                column: "supplierName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
