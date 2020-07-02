using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    interface ICompanyContactRepository
    {
        Task<CompanyContact> GetCompanyContact(Guid contactId);
        IQueryable<CompanyContact> GetContactsForCompany(Guid companyId);
        Task<CompanyContact> AddCompanyContact(CompanyContact companyContact);
        Task<CompanyContact> UpdateCompanyContact(CompanyContact companyContact);
        Task DeleteCompanyContact(Guid contactId);
    }
}
