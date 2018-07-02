using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Data.Model;
using Data.ViewModel;

namespace CustomMultipartFormDataStreamProvider.CompanyDataService
{
    public interface ICompanyDataService
    {
        Task<bool> SaveCompanyData(Stream stream);

        Task<List<CompanyViewModel>> GetAllCompanies();
    }
}