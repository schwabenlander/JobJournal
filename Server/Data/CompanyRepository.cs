using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly JobJournalContext _db;

        public CompanyRepository(JobJournalContext context)
        {
            _db = context;
        }

        public async Task<Company> GetCompany(Guid companyId)
        {
            return await _db.Companies.FindAsync(companyId);
        }

        public IEnumerable<Company> GetCompaniesForUser(Guid userId)
        {
            return _db.Companies.Where(c => c.UserId == userId);
        }

        public async Task<Company> AddCompany(Company company)
        {
            var newCompany = _db.Companies.Add(company);
            await _db.SaveChangesAsync();

            return newCompany.Entity;
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            if (company == null) return null;
            var companyToUpdate = await _db.Companies.FindAsync(company.Id);

            companyToUpdate.CompanyName = company.CompanyName;
            companyToUpdate.WebsiteURI = company.WebsiteURI;
            companyToUpdate.PhoneNumber = company.PhoneNumber;
            companyToUpdate.EmailAddress = company.EmailAddress;
            companyToUpdate.City = company.City;
            companyToUpdate.State = company.State;

            var updatedCompany = _db.Companies.Update(companyToUpdate);
            await _db.SaveChangesAsync();

            return updatedCompany.Entity;
        }

        public async Task DeleteCompany(Guid companyId)
        {
            var company = await _db.Companies.FindAsync(companyId);
            if (company == null) return;

            _db.Companies.Remove(company);
            await _db.SaveChangesAsync();
        }
    }
}
