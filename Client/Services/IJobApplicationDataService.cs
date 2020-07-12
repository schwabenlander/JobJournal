﻿using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public interface IJobApplicationDataService
    {
        Task<IEnumerable<JobApplicationDTO>> GetJobApplicationsAsync(Guid userId);

        Task<JobApplicationDTO> GetJobApplicationAsync(Guid id);

        Task<JobApplicationDTO> AddJobApplicationAsync(JobApplicationDTO jobApplication);

        Task UpdateJobApplicationAsync(JobApplicationDTO jobApplication);

        Task DeleteJobApplicationAsync(Guid id);
    }
}