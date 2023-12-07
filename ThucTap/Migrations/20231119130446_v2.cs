using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_CartsCart_id",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Products_Product_id1",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_User_id1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Orders_Order_id1",
                table: "Order_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Products_Product_id1",
                table: "Order_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Statuses_Order_status_id1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_Payment_id1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_User_id1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Images_Products_Product_id1",
                table: "Product_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Reviews_Products_Product_id1",
                table: "Product_Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Reviews_Users_User_id1",
                table: "Product_Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Product_Types_Product_type_id1",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Product_type_id1",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "User_id1",
                table: "Product_Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Product_id1",
                table: "Product_Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Product_id1",
                table: "Product_Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "User_id1",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Payment_id1",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Order_status_id1",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Product_id1",
                table: "Order_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Order_id1",
                table: "Order_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "User_id1",
                table: "Carts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Product_id1",
                table: "Cart_Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartsCart_id",
                table: "Cart_Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Account_id = table.Column<int>(type: "int", nullable: false),
                    Account_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Accounts_Account_id1",
                        column: x => x.Account_id1,
                        principalTable: "Accounts",
                        principalColumn: "Account_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_Account_id1",
                table: "Tokens",
                column: "Account_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Carts_CartsCart_id",
                table: "Cart_Items",
                column: "CartsCart_id",
                principalTable: "Carts",
                principalColumn: "Cart_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Products_Product_id1",
                table: "Cart_Items",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_User_id1",
                table: "Carts",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Orders_Order_id1",
                table: "Order_Details",
                column: "Order_id1",
                principalTable: "Orders",
                principalColumn: "Order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Products_Product_id1",
                table: "Order_Details",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Statuses_Order_status_id1",
                table: "Orders",
                column: "Order_status_id1",
                principalTable: "Order_Statuses",
                principalColumn: "Order_status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_Payment_id1",
                table: "Orders",
                column: "Payment_id1",
                principalTable: "Payments",
                principalColumn: "Payment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_User_id1",
                table: "Orders",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Images_Products_Product_id1",
                table: "Product_Images",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Reviews_Products_Product_id1",
                table: "Product_Reviews",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Reviews_Users_User_id1",
                table: "Product_Reviews",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Product_Types_Product_type_id1",
                table: "Products",
                column: "Product_type_id1",
                principalTable: "Product_Types",
                principalColumn: "Product_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_CartsCart_id",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Products_Product_id1",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_User_id1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Orders_Order_id1",
                table: "Order_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Products_Product_id1",
                table: "Order_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Statuses_Order_status_id1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_Payment_id1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_User_id1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Images_Products_Product_id1",
                table: "Product_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Reviews_Products_Product_id1",
                table: "Product_Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Reviews_Users_User_id1",
                table: "Product_Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Product_Types_Product_type_id1",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.AlterColumn<int>(
                name: "Product_type_id1",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_id1",
                table: "Product_Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Product_id1",
                table: "Product_Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Product_id1",
                table: "Product_Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_id1",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Payment_id1",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order_status_id1",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Product_id1",
                table: "Order_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order_id1",
                table: "Order_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_id1",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Product_id1",
                table: "Cart_Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartsCart_id",
                table: "Cart_Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Carts_CartsCart_id",
                table: "Cart_Items",
                column: "CartsCart_id",
                principalTable: "Carts",
                principalColumn: "Cart_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Products_Product_id1",
                table: "Cart_Items",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_User_id1",
                table: "Carts",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Orders_Order_id1",
                table: "Order_Details",
                column: "Order_id1",
                principalTable: "Orders",
                principalColumn: "Order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Products_Product_id1",
                table: "Order_Details",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Statuses_Order_status_id1",
                table: "Orders",
                column: "Order_status_id1",
                principalTable: "Order_Statuses",
                principalColumn: "Order_status_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_Payment_id1",
                table: "Orders",
                column: "Payment_id1",
                principalTable: "Payments",
                principalColumn: "Payment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_User_id1",
                table: "Orders",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Images_Products_Product_id1",
                table: "Product_Images",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Reviews_Products_Product_id1",
                table: "Product_Reviews",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Reviews_Users_User_id1",
                table: "Product_Reviews",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Product_Types_Product_type_id1",
                table: "Products",
                column: "Product_type_id1",
                principalTable: "Product_Types",
                principalColumn: "Product_type_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
