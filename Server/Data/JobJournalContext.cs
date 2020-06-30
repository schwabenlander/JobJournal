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
        }
    }
}
