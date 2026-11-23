using System;
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
                name: "addresstypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    addresstype = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresstypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city = table.Column<string>(type: "character varying(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    lastname = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    email = table.Column<string>(type: "character varying(128)", unicode: false, maxLength: 128, nullable: false),
                    phone = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoicetypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    invoicetype = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoicetypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    suppliername = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "postalcodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    postalcode = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postalcodes", x => x.id);
                    table.ForeignKey(
                        name: "FK_postalcodes_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salesorders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ordernumber = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    orderdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    customer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesorders", x => x.id);
                    table.ForeignKey(
                        name: "FK_salesorders_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(2048)", unicode: false, maxLength: 2048, nullable: true),
                    imageurl = table.Column<string>(type: "character varying(128)", unicode: false, maxLength: 128, nullable: true),
                    itemnumber = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    productname = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    supplier_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.CheckConstraint("CK_Product_Price_NonNegative", "price >= 0");
                    table.ForeignKey(
                        name: "FK_products_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    addressline = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    postalcode_id = table.Column<int>(type: "integer", nullable: false),
                    addresstype_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_addresstypes_addresstype_id",
                        column: x => x.addresstype_id,
                        principalTable: "addresstypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_addresses_postalcodes_postalcode_id",
                        column: x => x.postalcode_id,
                        principalTable: "postalcodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    invoicenumber = table.Column<int>(type: "integer", nullable: false),
                    invoicedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    duedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    invoicetype_id = table.Column<int>(type: "integer", nullable: false),
                    order_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoices_invoicetypes_invoicetype_id",
                        column: x => x.invoicetype_id,
                        principalTable: "invoicetypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoices_salesorders_order_id",
                        column: x => x.order_id,
                        principalTable: "salesorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderitems",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    discount = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderitems", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_orderitems_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orderitems_salesorders_order_id",
                        column: x => x.order_id,
                        principalTable: "salesorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customeraddresses",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customeraddresses", x => new { x.address_id, x.customer_id });
                    table.ForeignKey(
                        name: "FK_customeraddresses_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customeraddresses_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplieraddresses",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    supplier_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplieraddresses", x => new { x.address_id, x.supplier_id });
                    table.ForeignKey(
                        name: "FK_supplieraddresses_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplieraddresses_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "suppliers",
                columns: new[] { "id", "suppliername" },
                values: new object[,]
                {
                    { 1, "Asics" },
                    { 2, "Nike" },
                    { 3, "CLN Athletics" },
                    { 4, "Swix" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "description", "imageurl", "itemnumber", "productname", "price", "supplier_id" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet", "https://res.cloudinary.com/softtech-dev/image/upload/v1786556514/shoe-1_qig4ut.jpg", "1000", "Core 2000", 1295m, 1 },
                    { 2, "Lorem ipsum dolor sit amet", "https://res.cloudinary.com/softtech-dev/image/upload/v1786556530/shoe-3_qbzcwy.jpg", "1001", "Gel 27", 2295m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_addresstype_id",
                table: "addresses",
                column: "addresstype_id");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_postalcode_id",
                table: "addresses",
                column: "postalcode_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_city",
                table: "cities",
                column: "city",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customeraddresses_customer_id",
                table: "customeraddresses",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_email",
                table: "customers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_invoicetype_id",
                table: "invoices",
                column: "invoicetype_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_order_id",
                table: "invoices",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_orderitems_product_id",
                table: "orderitems",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_postalcodes_city_id",
                table: "postalcodes",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_postalcodes_postalcode",
                table: "postalcodes",
                column: "postalcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_itemnumber",
                table: "products",
                column: "itemnumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_supplier_id",
                table: "products",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_salesorders_customer_id",
                table: "salesorders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_salesorders_ordernumber",
                table: "salesorders",
                column: "ordernumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_supplieraddresses_supplier_id",
                table: "supplieraddresses",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_suppliername",
                table: "suppliers",
                column: "suppliername",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customeraddresses");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "orderitems");

            migrationBuilder.DropTable(
                name: "supplieraddresses");

            migrationBuilder.DropTable(
                name: "invoicetypes");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "salesorders");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "addresstypes");

            migrationBuilder.DropTable(
                name: "postalcodes");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
