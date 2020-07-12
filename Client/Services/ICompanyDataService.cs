using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public interface ICompanyDataService
    {
        Task<IEnumerable<CompanyDTO>> GetCompaniesAsync(Guid userId);

        Task<CompanyDTO> GetCompanyAsync(Guid id);

        Task<CompanyDTO> AddCompanyAsync(CompanyDTO company);

        Task UpdateCompanyAsync(CompanyDTO company);

        Task DeleteCompanyAsync(Guid id);
    }
}
