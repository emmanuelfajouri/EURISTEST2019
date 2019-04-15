using EURIS.Data.Contracts;
using EURIS.Entities.Models;

namespace EURIS.Data.Repositories
{
    public class CatalogRepository: RepositoryBase<Catalog>
    {
        public CatalogRepository(IEURISContext context) : base(context)
        {
        }
    }
}
