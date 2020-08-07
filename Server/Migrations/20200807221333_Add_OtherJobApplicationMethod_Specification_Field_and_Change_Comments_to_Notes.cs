using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobJournal.Server.Migrations
{
    public partial class Add_OtherJobApplicationMethod_Specification_Field_and_Change_Comments_to_Notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "CompanyContact");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "JobApplication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherApplicationMethod",
                table: "JobApplication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CompanyContact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Company",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("ad94a572-5104-4303-82f7-fac0a7d06897"),
                column: "Notes",
                value: "Great company to work for.");

            migrationBuilder.UpdateData(
                table: "CompanyContact",
                keyColumn: "Id",
                keyValue: new Guid("1e98b65b-c56d-470d-b509-148ac693a013"),
                column: "Notes",
                value: "Sean's a great guy and a handsome fellow.");

            migrationBuilder.UpdateData(
                table: "JobApplication",
                keyColumn: "Id",
                keyValue: new Guid("58e55e99-cbad-4c93-b804-fe8c265f9835"),
                column: "Notes",
                value: "This is my dream job.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "OtherApplicationMethod",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CompanyContact");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "JobApplication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "CompanyContact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: new Guid("ad94a572-5104-4303-82f7-fac0a7d06897"),
                column: "Comments",
                value: "Great company to work for.");

            migrationBuilder.UpdateData(
                table: "CompanyContact",
                keyColumn: "Id",
                keyValue: new Guid("1e98b65b-c56d-470d-b509-148ac693a013"),
                column: "Comments",
                value: "Sean's a great guy and a handsome fellow.");

            migrationBuilder.UpdateData(
                table: "JobApplication",
                keyColumn: "Id",
                keyValue: new Guid("58e55e99-cbad-4c93-b804-fe8c265f9835"),
                column: "Comments",
                value: "This is my dream job.");
        }
    }
}
