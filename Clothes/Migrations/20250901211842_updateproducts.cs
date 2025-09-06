using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothes.Migrations
{
    /// <inheritdoc />
    public partial class updateproducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ProductSize",
                newName: "Sizes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sizes",
                table: "ProductSize",
                newName: "Size");
        }
    }
}
