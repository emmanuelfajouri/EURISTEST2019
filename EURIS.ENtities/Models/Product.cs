using System.Collections.Generic;

namespace EURIS.Entities.Models
{
    public class Product
    {
        public Product()
        {
            Catalogs = new List<Catalog>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual List<Catalog> Catalogs { get; set; }
        public virtual ICollection<ProductCatalog> ProductCatalogs { get; set; }
    }

    public class ProductCatalog
    {
        public int ProductId { get; set; }

        public int CatalogId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Catalog Catalog { get; set; }
    }
}
