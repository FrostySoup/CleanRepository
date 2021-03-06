﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;

namespace Repository.CompanyRepository
{
    public class CompanyRepository : BaseCompanyRepository
    {
        public override async Task AddCompaniesList(List<Company> companiesList)
        {
            using (var db = new ImportContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;

                foreach (var company in companiesList)
                {
                    db.Companies.Add(company);
                }
                await db.SaveChangesAsync();
            }
        }
    }
}