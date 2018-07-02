using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Data.ViewModel;

namespace Repository.CompanyRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        public async Task<Company> AddCompany(Company company)
        {
            using (var db = new ImportContext())
            {
                db.Companies.Add(company);
                await db.SaveChangesAsync();
            }

            return company;
        }

        public async Task<List<CompanyViewModel>> GetAllCompanies()
        {
            using (var db = new ImportContext())
            {
                return await db.Companies
                    .Select(c => new CompanyViewModel
                    {
                        ExternalId = c.ExternalId,
                        Fax = c.Fax,
                        Phone = c.Phone,
                        CompanyType = c.CompanyType,
                        IsWarehouse = c.IsWarehouse,
                        IsForwarder = c.IsForwarder,
                        TradingName = c.TradingName
                    })
                    .ToListAsync();
            }
        }
    }
}
