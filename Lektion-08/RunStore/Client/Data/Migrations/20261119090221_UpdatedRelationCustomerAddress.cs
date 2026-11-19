using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelationCustomerAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "addresses",
                newName: "id");

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customeraddresses_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customeraddresses_customer_id",
                table: "customeraddresses",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customeraddresses");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "addresses",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "AddressCustomer",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "integer", nullable: false),
                    CustomersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCustomer", x => new { x.AddressesId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_AddressCustomer_addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressCustomer_customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressCustomer_CustomersId",
                table: "AddressCustomer",
                column: "CustomersId");
        }
    }
}
