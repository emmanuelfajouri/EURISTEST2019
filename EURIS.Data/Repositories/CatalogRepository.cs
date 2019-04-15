using EURIS.Data.Contracts;
using EURIS.Entities.Models;

namespace EURIS.Data.Repositories
{
    public class CatalogRepository: RepositoryBase<Catalog>
    {
        public CatalogRepository(IEURISContext context) : base(context)
        {
        }

        public override void Update(Catalog entity)
        {
            foreach (var prod in entity.Products)
            {
                Context.Products.Attach(prod);
            }
            base.Update(entity);
        }
    }
}
