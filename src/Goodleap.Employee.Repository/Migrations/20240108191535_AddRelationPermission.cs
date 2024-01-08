using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goodleap.Employee.Core.Migrations
{
    public partial class AddRelationPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_EmployeePermissions_EmployeePermissionEmployeeId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_EmployeePermissionEmployeeId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePermissions",
                table: "EmployeePermissions");

            migrationBuilder.DropColumn(
                name: "EmployeePermissionEmployeeId",
                table: "Permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EmployeePermissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PermissionId",
                table: "EmployeePermissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePermissions",
                table: "EmployeePermissions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_TypeId",
                table: "Permissions",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_EmployeeId",
                table: "EmployeePermissions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_PermissionId",
                table: "EmployeePermissions",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePermissions_Permissions_PermissionId",
                table: "EmployeePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionTypes_TypeId",
                table: "Permissions",
                column: "TypeId",
                principalTable: "PermissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermissions_Permissions_PermissionId",
                table: "EmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionTypes_TypeId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_TypeId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePermissions",
                table: "EmployeePermissions");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePermissions_EmployeeId",
                table: "EmployeePermissions");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePermissions_PermissionId",
                table: "EmployeePermissions");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeePermissions");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "EmployeePermissions");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeePermissionEmployeeId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePermissions",
                table: "EmployeePermissions",
                column: "EmployeeId");

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
    }
}
