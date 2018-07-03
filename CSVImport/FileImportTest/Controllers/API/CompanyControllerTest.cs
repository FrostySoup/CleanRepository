using Moq;
using Data.ViewModel;
using System.Net.Http;
using System.Web.Http;
using CSVImport.Controllers.API;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomMultipartFormDataStreamProvider.CompanyDataService;

namespace FileImportTest.Controllers.API
{
    [TestClass]
    public class CompanyControllerTest
    {
        private Mock<ICompanyDataService> _companyDataServiceMock;
        private CompanyController _companyController;

        [TestInitialize]
        public void SetUp()
        {
            _companyDataServiceMock = new Moq.Mock<ICompanyDataService>();
            _companyController = new CompanyController(_companyDataServiceMock.Object);
        }

        [TestMethod]
        public void GetCompanies_ValidCall_ReceiveCompanies()
        {
            var mockedCompanyViewModelData =
                new List<CompanyViewModel> {new CompanyViewModel(), new CompanyViewModel()};

            _companyDataServiceMock
                .Setup(c => c.GetAllCompanies())
                .ReturnsAsync(mockedCompanyViewModelData);

            _companyController.Request = new HttpRequestMessage();
            _companyController.Configuration = new HttpConfiguration();

            var response = _companyController.GetAllCompanies();

            var result = response.Result as OkNegotiatedContentResult<List<CompanyViewModel>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(mockedCompanyViewModelData.Count, result.Content.Count);
        }
    }
}