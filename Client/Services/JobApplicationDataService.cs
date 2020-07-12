using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public class JobApplicationDataService : IJobApplicationDataService
    {
        private readonly HttpClient _httpClient;

        public JobApplicationDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JobApplicationDTO> AddJobApplicationAsync(JobApplicationDTO jobApplication)
        {
            var response = await _httpClient.PostAsJsonAsync("api/jobapplication", jobApplication);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<JobApplicationDTO>();
            }

            return null;
        }

        public async Task DeleteJobApplicationAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/jobapplication/{id}");
        }

        public async Task<JobApplicationDTO> GetJobApplicationAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<JobApplicationDTO>($"api/jobapplication/{id}");
        }

        public async Task<IEnumerable<JobApplicationDTO>> GetJobApplicationsAsync(Guid userId)
        {
            return await _httpClient.GetFromJsonAsync<List<JobApplicationDTO>>($"api/jobapplication/user/{userId}");
        }

        public async Task UpdateJobApplicationAsync(JobApplicationDTO jobApplication)
        {
            await _httpClient.PutAsJsonAsync($"api/jobapplication/{jobApplication.Id}", jobApplication);
        }
    }
}
