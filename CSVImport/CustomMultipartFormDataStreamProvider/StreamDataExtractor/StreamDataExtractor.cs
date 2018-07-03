using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CustomMultipartFormDataStreamProvider.FileColumnsFormatter;
using Data.Model;
using Repository.CompanyRepository;

namespace CustomMultipartFormDataStreamProvider.StreamDataExtractor
{
    public class StreamDataExtractor : IStreamDataExtractor
    {
        private readonly IFileColumnsFormatter _fileColumnsFormatter;
        private readonly ICompanyRepository _companyRepository;

        private const int maximumStackSize = 10000;

        public StreamDataExtractor(IFileColumnsFormatter fileColumnsFormatter, ICompanyRepository companyRepository)
        {
            _fileColumnsFormatter = fileColumnsFormatter;
            _companyRepository = companyRepository;
        }

        public async Task<bool> ExtractDataFromStream(Stream stream)
        {
            var columnsList = new List<int>();
            var companiesList = new List<Company>();

            Dictionary<string, int> headers = null;

            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line?.Split(',');

                    if (values?.Length > 1)
                    {
                        if (headers != null)
                        {
                            var company = _fileColumnsFormatter.FormCompany(values, columnsList);
                            companiesList.Add(company);
                        }
                        else
                        {
                            headers = _fileColumnsFormatter.ReadColumnIndexes(values);
                            columnsList = _fileColumnsFormatter.FormValidColumnsList(headers);
                        }
                    }

                    if (companiesList.Count >= maximumStackSize)
                    {
                        await _companyRepository.AddCompaniesList(companiesList);
                        companiesList = new List<Company>();
                    }
                }
            }

            if (companiesList.Any())
                await _companyRepository.AddCompaniesList(companiesList);

            return true;
        }
    }
}