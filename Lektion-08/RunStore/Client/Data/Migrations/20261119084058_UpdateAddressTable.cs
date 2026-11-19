using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCustomer_Address_AddressesId",
                table: "AddressCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "addresses");

            migrationBuilder.RenameColumn(
                name: "AddressLine",
                table: "addresses",
                newName: "addressline");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "addresses",
                newName: "customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCustomer_addresses_AddressesId",
                table: "AddressCustomer",
                column: "AddressesId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCustomer_addresses_AddressesId",
                table: "AddressCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "addressline",
                table: "Address",
                newName: "AddressLine");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "Address",
                newName: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCustomer_Address_AddressesId",
                table: "AddressCustomer",
                column: "AddressesId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
