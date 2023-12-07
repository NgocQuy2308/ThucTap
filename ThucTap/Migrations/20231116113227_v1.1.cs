using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Decentralizations_DecentralizationId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_Account_id1",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Account_id1",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResetPasswordTokenExpiry",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DecentralizationId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Decentralizations_DecentralizationId",
                table: "Accounts",
                column: "DecentralizationId",
                principalTable: "Decentralizations",
                principalColumn: "decentralization_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_Account_id1",
                table: "Users",
                column: "Account_id1",
                principalTable: "Accounts",
                principalColumn: "Account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Decentralizations_DecentralizationId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_Account_id1",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Account_id1",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResetPasswordTokenExpiry",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DecentralizationId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Decentralizations_DecentralizationId",
                table: "Accounts",
                column: "DecentralizationId",
                principalTable: "Decentralizations",
                principalColumn: "decentralization_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_Account_id1",
                table: "Users",
                column: "Account_id1",
                principalTable: "Accounts",
                principalColumn: "Account_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
