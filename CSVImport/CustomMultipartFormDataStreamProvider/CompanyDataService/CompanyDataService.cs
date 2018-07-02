using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CustomMultipartFormDataStreamProvider.StreamDataExtractor;
using Data.Model;
using Data.ViewModel;
using Repository.CompanyRepository;

namespace CustomMultipartFormDataStreamProvider.CompanyDataService
{
    public class CompanyDataService: ICompanyDataService
    {
        private readonly IStreamDataExtractor _streamDataExtractor;
        private readonly ICompanyRepository _companyRepository;

        public CompanyDataService(IStreamDataExtractor streamDataExtractor, ICompanyRepository companyRepository)
        {
            _streamDataExtractor = streamDataExtractor;
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyViewModel>> GetAllCompanies()
        {
            return await _companyRepository.GetAllCompanies();
        }

        public async Task<bool> SaveCompanyData(Stream stream)
        {
            return await _streamDataExtractor.ExtractDataFromStream(stream);
        }
    }
}
