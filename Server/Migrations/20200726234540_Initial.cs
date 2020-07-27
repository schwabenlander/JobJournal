using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobJournal.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    WebsiteURI = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    FirstContactDate = table.Column<DateTime>(nullable: true),
                    MostRecentContactDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContact_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    ApplicationStatusId = table.Column<int>(nullable: false),
                    ApplicationMethodId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplication_ApplicationMethod_ApplicationMethodId",
                        column: x => x.ApplicationMethodId,
                        principalTable: "ApplicationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplication_ApplicationStatus_ApplicationStatusId",
                        column: x => x.ApplicationStatusId,
                        principalTable: "ApplicationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplication_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 5, "Ghosted" },
                    { 6, "Hired" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "City", "Comments", "CompanyName", "EmailAddress", "PhoneNumber", "State", "UserId", "WebsiteURI" },
                values: new object[] { new Guid("ad94a572-5104-4303-82f7-fac0a7d06897"), "Muscatine", "Great company to work for.", "Schwabenlander.com", "sean@schwabenlander.com", "(202) 794-0474", "IA", new Guid("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8"), "https://www.schwabenlander.com" });

            migrationBuilder.InsertData(
                table: "CompanyContact",
                columns: new[] { "Id", "Comments", "CompanyId", "EmailAddress", "FirstContactDate", "FullName", "JobTitle", "MostRecentContactDate", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("1e98b65b-c56d-470d-b509-148ac693a013"), "Sean's a great guy and a handsome fellow.", new Guid("ad94a572-5104-4303-82f7-fac0a7d06897"), "sean@schwabenlander.net", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sean Schwabenlander", "CEO", null, "(612) 810-4212", new Guid("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8") });

            migrationBuilder.InsertData(
                table: "JobApplication",
                columns: new[] { "Id", "ApplicationDate", "ApplicationMethodId", "ApplicationStatusId", "Comments", "CompanyId", "JobTitle", "UserId" },
                values: new object[] { new Guid("58e55e99-cbad-4c93-b804-fe8c265f9835"), new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "This is my dream job.", new Guid("ad94a572-5104-4303-82f7-fac0a7d06897"), "Engineer", new Guid("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8") });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContact_CompanyId",
                table: "CompanyContact",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ApplicationMethodId",
                table: "JobApplication",
                column: "ApplicationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ApplicationStatusId",
                table: "JobApplication",
                column: "ApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_CompanyId",
                table: "JobApplication",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyContact");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "ApplicationMethod");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
