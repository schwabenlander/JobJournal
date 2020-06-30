using JobJournal.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public class JobJournalContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyContact> CompanyContacts { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        public JobJournalContext(DbContextOptions<JobJournalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<CompanyContact>().ToTable("CompanyContact");
            modelBuilder.Entity<JobApplication>().ToTable("JobApplication");

            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = Guid.Parse("ad94a572-5104-4303-82f7-fac0a7d06897"),
                CompanyName = "Schwabenlander.com",
                WebsiteURI = "https://www.schwabenlander.com",
                PhoneNumber = "(202) 794-0474",
                EmailAddress = "sean@schwabenlander.com",
                City = "Muscatine",
                State = "IA",
                UserId = Guid.Parse("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8")
            });

            modelBuilder.Entity<CompanyContact>().HasData(new CompanyContact
            {
                Id = Guid.Parse("1e98b65b-c56d-470d-b509-148ac693a013"),
                CompanyId = Guid.Parse("ad94a572-5104-4303-82f7-fac0a7d06897"),
                FullName = "Sean Schwabenlander",
                EmailAddress = "sean@schwabenlander.net",
                PhoneNumber = "(612) 810-4212",
                FirstContactDate = new DateTime(2020, 06, 01),
                UserId = Guid.Parse("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8")
            });

            modelBuilder.Entity<JobApplication>().HasData(new JobApplication
            {
                Id = Guid.Parse("58e55e99-cbad-4c93-b804-fe8c265f9835"),
                CompanyId = Guid.Parse("ad94a572-5104-4303-82f7-fac0a7d06897"),
                JobTitle = "CEO",
                ApplicationDate = new DateTime(2020, 06, 30),
                ApplicationMethod = ApplicationMethod.DirectInPerson,
                ApplicationStatus = ApplicationStatus.Applied,
                UserId = Guid.Parse("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8")
            });

        }
    }
}
