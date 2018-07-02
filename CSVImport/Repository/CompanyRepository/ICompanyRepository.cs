using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;
using Data.ViewModel;

namespace Repository.CompanyRepository
{
    public interface ICompanyRepository
    {
        Task<Company> AddCompany(Company company);
        Task<List<CompanyViewModel>> GetAllCompanies();
    }
}
