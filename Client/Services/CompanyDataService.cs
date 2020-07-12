using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public class CompanyDataService : ICompanyDataService
    {
        private readonly HttpClient _httpClient;

        public CompanyDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CompanyDTO>> GetCompaniesAsync(Guid userId)
        {
            return await _httpClient.GetFromJsonAsync<List<CompanyDTO>>($"api/company/all/{userId}");
        }

        public async Task<CompanyDTO> GetCompanyAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<CompanyDTO>($"api/company/{id}");
        }

        public async Task<CompanyDTO> PostCompanyAsync(CompanyDTO company)
        {
            var response = await _httpClient.PostAsJsonAsync<CompanyDTO>("api/company", company);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CompanyDTO>();
            }

            return null;
        }
    }
}
