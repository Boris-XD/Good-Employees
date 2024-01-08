using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goodleap.Employee.Core.Migrations
{
    public partial class AddRelationInTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeePermissionEmployeeId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeePermissions",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePermissions", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeePermissions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EmployeePermissionEmployeeId",
                table: "Permissions",
                column: "EmployeePermissionEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_EmployeePermissions_EmployeePermissionEmployeeId",
                table: "Permissions",
                column: "EmployeePermissionEmployeeId",
                principalTable: "EmployeePermissions",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_EmployeePermissions_EmployeePermissionEmployeeId",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "EmployeePermissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_EmployeePermissionEmployeeId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "EmployeePermissionEmployeeId",
                table: "Permissions");
        }
    }
}
