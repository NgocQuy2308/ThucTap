using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap.Migrations
{
    /// <inheritdoc />
    public partial class v21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id1 = table.Column<int>(type: "int", nullable: true),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmEmails_Users_User_id1",
                        column: x => x.User_id1,
                        principalTable: "Users",
                        principalColumn: "User_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmEmails_User_id1",
                table: "ConfirmEmails",
                column: "User_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmEmails");
        }
    }
}
