using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Model;

namespace Repository
{
    public class ImportContext : DbContext
    {

        public ImportContext() : base("ImportContext")
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}