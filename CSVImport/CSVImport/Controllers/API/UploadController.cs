using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CustomMultipartFormDataStreamProvider.CompanyDataService;

namespace CSVImport.Controllers.API
{
    [RoutePrefix("api")]
    public class UploadController : ApiController
    {
        private readonly ICompanyDataService _companyDataService;

        public UploadController(ICompanyDataService companyDataService)
        {
            _companyDataService = companyDataService;
        }

        [Route("fileupload")]
        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> Post()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                using (var stream = await Request.Content.ReadAsStreamAsync())
                {
                    await _companyDataService.SaveCompanyData(stream);
                    stream.Close();
                }

                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }
    }
}