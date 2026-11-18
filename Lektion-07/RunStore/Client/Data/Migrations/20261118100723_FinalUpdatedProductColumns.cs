using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalUpdatedProductColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ItemNumber",
                table: "products",
                newName: "itemNumber");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "products",
                newName: "imageUrl");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "productName");

            migrationBuilder.AlterColumn<string>(
                name: "itemNumber",
                table: "products",
                type: "VARCHAR(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "imageUrl",
                table: "products",
                type: "VARCHAR(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "products",
                type: "VARCHAR(80)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(80)",
                oldMaxLength: 80);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "itemNumber",
                table: "products",
                newName: "ItemNumber");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "products",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "ItemNumber",
                table: "products",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(15)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "products",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "products",
                type: "character varying(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(80)");
        }
    }
}
