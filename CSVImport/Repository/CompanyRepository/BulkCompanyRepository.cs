using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;

namespace Repository.CompanyRepository
{
    public class BulkCompanyRepository : BaseCompanyRepository
    {
        public override async Task AddCompaniesList(List<Company> companiesList)
        {
            using (var db = new ImportContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Companies.AddRange(companiesList);
                await db.BulkSaveChangesAsync();
            }
        }
    }
}