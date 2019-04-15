using EURIS.Data.Contracts;
using EURIS.Entities.Models;

namespace EURIS.Data.Repositories
{

    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(IEURISContext context) : base(context)
        {
        }
    }
}
