using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "products",
                newName: "description");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "products",
                type: "VARCHAR(2048)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2048)",
                oldMaxLength: 2048,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "products",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "products",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2048)",
                oldNullable: true);
        }
    }
}
