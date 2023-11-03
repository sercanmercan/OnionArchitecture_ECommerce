using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_OrderProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrdersId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "OrderProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "OrderProduct",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrderProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderProduct",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "OrderProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "OrderProduct",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedUserId",
                table: "OrderProduct",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OrderProduct",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "OrderProduct",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrderId",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrderProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderProduct",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                columns: new[] { "OrdersId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrdersId",
                table: "OrderProduct",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
