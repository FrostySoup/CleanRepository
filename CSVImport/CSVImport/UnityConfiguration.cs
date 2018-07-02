using CustomMultipartFormDataStreamProvider.CompanyDataService;
using CustomMultipartFormDataStreamProvider.FileColumnsFormatter;
using CustomMultipartFormDataStreamProvider.StreamDataExtractor;
using Repository.CompanyRepository;
using Unity;

namespace CSVImport
{
    public class UnityConfiguration
    {
        public static IUnityContainer Config()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICompanyDataService, CompanyDataService>();
            container.RegisterType<IFileColumnsFormatter, FileColumnsFormatter>();
            container.RegisterType<IStreamDataExtractor, StreamDataExtractor>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();

            // return the container so it can be used for the dependencyresolver.  
            return container;
        }
    }
}