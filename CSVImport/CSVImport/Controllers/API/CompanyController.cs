using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CustomMultipartFormDataStreamProvider.CompanyDataService;
using Data.ViewModel;

namespace CSVImport.Controllers.API
{
    [RoutePrefix("api")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyDataService _companyDataService;

        public CompanyController(ICompanyDataService companyDataService)
        {
            _companyDataService = companyDataService;
        }

        [ResponseType(typeof(CompanyViewModel))]
        [Route("companies")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCompanies()
        {
            var companies = await _companyDataService.GetAllCompanies();

            return Ok(companies);
        }
    }
}