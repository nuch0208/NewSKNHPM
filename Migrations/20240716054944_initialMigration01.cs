using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SKNHPM.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "NurseRequests");

            migrationBuilder.DropColumn(
                name: "ReqDate",
                table: "NurseRequests");

            migrationBuilder.RenameColumn(
                name: "UrentType",
                table: "NurseRequests",
                newName: "UrgentType");

            migrationBuilder.RenameColumn(
                name: "EndPoint",
                table: "NurseRequests",
                newName: "JobStatusName");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "NurseRequests",
                newName: "EndPoint4");

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "NurseRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndPoint1",
                table: "NurseRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndPoint2",
                table: "NurseRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndPoint3",
                table: "NurseRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "NurseRequests");

            migrationBuilder.DropColumn(
                name: "EndPoint1",
                table: "NurseRequests");

            migrationBuilder.DropColumn(
                name: "EndPoint2",
                table: "NurseRequests");

            migrationBuilder.DropColumn(
                name: "EndPoint3",
                table: "NurseRequests");

            migrationBuilder.RenameColumn(
                name: "UrgentType",
                table: "NurseRequests",
                newName: "UrentType");

            migrationBuilder.RenameColumn(
                name: "JobStatusName",
                table: "NurseRequests",
                newName: "EndPoint");

            migrationBuilder.RenameColumn(
                name: "EndPoint4",
                table: "NurseRequests",
                newName: "Department");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "NurseRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReqDate",
                table: "NurseRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
