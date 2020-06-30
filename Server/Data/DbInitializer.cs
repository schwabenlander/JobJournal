using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(JobJournalContext context)
        {
            context.Database.EnsureCreated();

            // Look for any job applications
            //if (context.JobApplications.Any())
            //{
            //    return;   // DB has already been seeded
            //}
            //
            //var companies = new Company[]
            //{
            //};
        }
    }
}
