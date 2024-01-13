using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_PhuongNam_v1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class parentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Categories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
