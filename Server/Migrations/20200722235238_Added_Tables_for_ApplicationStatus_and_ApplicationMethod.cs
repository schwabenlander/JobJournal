using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobJournal.Server.Migrations
{
    public partial class Added_Tables_for_ApplicationStatus_and_ApplicationMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationMethod",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "JobApplication");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationMethodId",
                table: "JobApplication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatusId",
                table: "JobApplication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationMethod",
                columns: new[] { "Id", "Method" },
                values: new object[,]
                {
                    { 1, "Direct (Online)" },
                    { 2, "Direct (Email)" },
                    { 3, "Direct (In-Person)" },
                    { 4, "Recruiter" },
                    { 5, "Friend" },
                    { 6, "LinkedIn" },
                    { 7, "Indeed" },
                    { 8, "Monster" },
                    { 9, "Other" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Applied" },
                    { 2, "Interviewing" },
                    { 3, "Declined" },
                    { 4, "Rejected" },
                    { 5, "Hired" }
                });

            migrationBuilder.UpdateData(
                table: "JobApplication",
                keyColumn: "Id",
                keyValue: new Guid("58e55e99-cbad-4c93-b804-fe8c265f9835"),
                columns: new[] { "ApplicationMethodId", "ApplicationStatusId" },
                values: new object[] { 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ApplicationMethodId",
                table: "JobApplication",
                column: "ApplicationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ApplicationStatusId",
                table: "JobApplication",
                column: "ApplicationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_ApplicationMethod_ApplicationMethodId",
                table: "JobApplication",
                column: "ApplicationMethodId",
                principalTable: "ApplicationMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_ApplicationStatus_ApplicationStatusId",
                table: "JobApplication",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_ApplicationMethod_ApplicationMethodId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_ApplicationStatus_ApplicationStatusId",
                table: "JobApplication");

            migrationBuilder.DropTable(
                name: "ApplicationMethod");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropIndex(
                name: "IX_JobApplication_ApplicationMethodId",
                table: "JobApplication");

            migrationBuilder.DropIndex(
                name: "IX_JobApplication_ApplicationStatusId",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "ApplicationMethodId",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusId",
                table: "JobApplication");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationMethod",
                table: "JobApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatus",
                table: "JobApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "JobApplication",
                keyColumn: "Id",
                keyValue: new Guid("58e55e99-cbad-4c93-b804-fe8c265f9835"),
                columns: new[] { "ApplicationMethod", "ApplicationStatus" },
                values: new object[] { 3, 1 });
        }
    }
}
