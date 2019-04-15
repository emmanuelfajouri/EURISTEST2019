using EURIS.Data.Contracts;
using EURIS.Data.Initializer;
using EURIS.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            Database.SetInitializer<EURISContext>(new EURISContextInitializer());

            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ProductCatalog>()
                  .HasKey(i => new { i.ProductId, i.CatalogId });

            modelBuilder.Entity<ProductCatalog>()
            .HasRequired(i => i.Product)
            .WithMany(i => i.ProductCatalogs)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<ProductCatalog>()
               .HasRequired(i => i.Catalog)
               .WithMany(i => i.ProductCatalogs)
               .WillCascadeOnDelete(false);
        }
    

        public void Save()
        {
            SaveChanges();
        }
    }
}
