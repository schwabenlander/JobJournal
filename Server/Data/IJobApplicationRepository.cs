using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public interface IJobApplicationRepository
    {
        Task<JobApplication> GetJobApplication(Guid applicationId);
        IEnumerable<JobApplication> GetJobApplicationsForUser(Guid userId);
        Task<JobApplication> AddJobApplication(JobApplication application);
        Task<JobApplication> UpdateJobApplication(JobApplication application);
        Task DeleteJobApplication(Guid applicationId);
    }
}
