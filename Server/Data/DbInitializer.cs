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

            //Look for any job applications
            if (context.JobApplications.Any())
            {
                return;   // DB has already been seeded
            }

            var company = new Company
            {
                Id = Guid.Parse("ad94a572-5104-4303-82f7-fac0a7d06897"),
                CompanyName = "Schwabenlander.com",
                WebsiteURI = "https://www.schwabenlander.com",
                PhoneNumber = "(202) 794-0474",
                EmailAddress = "sean@schwabenlander.com",
                City = "Muscatine",
                State = "IA",
                UserId = Guid.Parse("9b27e7b5-1acf-42c8-919a-6394fd1ddfe8")
            };

            context.Companies.Add(company);
            context.SaveChanges();

            var contact = new CompanyContact
            {
                Id = Guid.Parse("1e98b65b-c56d-470d-b509-148ac693a013"),
                CompanyId = company.Id,
                FullName = "Sean Schwabenlander",
                EmailAddress = "sean@schwabenlander.net",
                PhoneNumber = "(612) 810-4212",
                FirstContactDate = new DateTime(2020, 06, 01),
                UserId = company.UserId
            };

            context.CompanyContacts.Add(contact);
            context.SaveChanges();

            var jobApplication = new JobApplication
            {
                Id = Guid.Parse("58e55e99-cbad-4c93-b804-fe8c265f9835"),
                CompanyId = company.Id,
                JobTitle = "CEO",
                ApplicationDate = new DateTime(2020, 06, 30),
                ApplicationMethod = ApplicationMethod.DirectInPerson,
                ApplicationStatus = ApplicationStatus.Applied,
                UserId = company.UserId
            };

            context.JobApplications.Add(jobApplication);
            context.SaveChanges();
        }
    }
}
