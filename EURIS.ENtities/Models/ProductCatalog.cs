namespace EURIS.Entities.Models
{
    public class ProductCatalog
    {
        public int ProductId { get; set; }

        public int CatalogId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Catalog Catalog { get; set; }
    }
}
