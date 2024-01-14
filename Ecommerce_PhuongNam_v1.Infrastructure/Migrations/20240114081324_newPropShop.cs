using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_PhuongNam_v1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newPropShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Shops",
                newName: "Logo");

            migrationBuilder.AddColumn<bool>(
                name: "IsMall",
                table: "Shops",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMall",
                table: "Shops");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Shops",
                newName: "Location");
        }
    }
}
