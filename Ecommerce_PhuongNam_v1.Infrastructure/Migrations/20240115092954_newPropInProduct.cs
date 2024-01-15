using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_PhuongNam_v1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newPropInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "Variant",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressDetailId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AddressDetailId",
                table: "Products",
                column: "AddressDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AddressDetails_AddressDetailId",
                table: "Products",
                column: "AddressDetailId",
                principalTable: "AddressDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AddressDetails_AddressDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AddressDetailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Variant");

            migrationBuilder.DropColumn(
                name: "AddressDetailId",
                table: "Products");
        }
    }
}
