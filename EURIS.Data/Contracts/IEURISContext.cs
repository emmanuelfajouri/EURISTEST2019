using EURIS.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EURIS.Data.Contracts
{
    public interface IEURISContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Catalog> Catalogs { get; set; }

        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Save();
        
    }
}
