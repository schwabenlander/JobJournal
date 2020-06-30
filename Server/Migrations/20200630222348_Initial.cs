using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobJournal.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    State = table.Column<string>(nullable: true)
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
                    PhoneNumber = table.Column<string>(nullable: true),
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
                    ApplicationStatus = table.Column<int>(nullable: false),
                    ApplicationMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplication_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "City", "CompanyName", "EmailAddress", "PhoneNumber", "State", "UserId", "WebsiteURI" },
                values: new object[] { new Guid("ad94a572-5104-4303-82f7-fac0a7d06897"), "Muscatine", "Schwabenlander.com", "sean@schwabenlander.com", "(202) 794-0474", "IA", new Guid("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8"), "https://www.schwabenlander.com" });

            migrationBuilder.InsertData(
                table: "CompanyContact",
                columns: new[] { "Id", "CompanyId", "EmailAddress", "FirstContactDate", "FullName", "MostRecentContactDate", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("1e98b65b-c56d-470d-b509-148ac693a013"), new Guid("ad94a572-5104-4303-82f7-fac0a7d06897"), "sean@schwabenlander.net", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sean Schwabenlander", null, "(612) 810-4212", new Guid("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8") });

            migrationBuilder.InsertData(
                table: "JobApplication",
                columns: new[] { "Id", "ApplicationDate", "ApplicationMethod", "ApplicationStatus", "CompanyId", "JobTitle", "UserId" },
                values: new object[] { new Guid("58e55e99-cbad-4c93-b804-fe8c265f9835"), new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, new Guid("ad94a572-5104-4303-82f7-fac0a7d06897"), "CEO", new Guid("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8") });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContact_CompanyId",
                table: "CompanyContact",
                column: "CompanyId");

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
                name: "Company");
        }
    }
}
