using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_suppliers_SupplierId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "products",
                newName: "supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_products_SupplierId",
                table: "products",
                newName: "IX_products_supplier_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_suppliers_supplier_id",
                table: "products",
                column: "supplier_id",
                principalTable: "suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_suppliers_supplier_id",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "supplier_id",
                table: "products",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_products_supplier_id",
                table: "products",
                newName: "IX_products_SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_suppliers_SupplierId",
                table: "products",
                column: "SupplierId",
                principalTable: "suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
