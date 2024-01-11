using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_PhuongNam_v1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Shops_ShopId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Variant_VariantId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ShopId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_VariantId",
                table: "OrderItem",
                newName: "IX_OrderItem_VariantId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Shops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OtpCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpCode", x => x.Id);
                    table.UniqueConstraint("AK_OtpCode_Email", x => x.Email);
                    table.UniqueConstraint("AK_OtpCode_PhoneNumber", x => x.PhoneNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shops_AccountId",
                table: "Shops",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountId",
                table: "Customers",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Variant_VariantId",
                table: "OrderItem",
                column: "VariantId",
                principalTable: "Variant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Accounts_AccountId",
                table: "Shops",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Variant_VariantId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Accounts_AccountId",
                table: "Shops");

            migrationBuilder.DropTable(
                name: "OtpCode");

            migrationBuilder.DropIndex(
                name: "IX_Shops_AccountId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_VariantId",
                table: "OrderItems",
                newName: "IX_OrderItems_VariantId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ShopId",
                table: "Accounts",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Shops_ShopId",
                table: "Accounts",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Variant_VariantId",
                table: "OrderItems",
                column: "VariantId",
                principalTable: "Variant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
