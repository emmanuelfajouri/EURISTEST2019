using EURIS.Data.Contracts;
using EURIS.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace EURIS.Data
{
    public class EURISContext : DbContext, IEURISContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }

        static EURISContext()
        {
            var dependencies = typeof(SqlProviderServices);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EURISContext>(null);
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
