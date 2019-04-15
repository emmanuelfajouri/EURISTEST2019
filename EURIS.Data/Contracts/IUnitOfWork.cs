using EURIS.Entities.Models;

namespace EURIS.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Catalog> CatalogRepository { get; }
        void SaveChanges();
    }

   
}
