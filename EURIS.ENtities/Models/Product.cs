using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EURIS.Entities.Models
{
    public class Product
    {
        public Product()
        {
            Catalogs = new List<Catalog>();
        }

        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual List<Catalog> Catalogs { get; set; }
        public virtual ICollection<ProductCatalog> ProductCatalogs { get; set; }
    }
}
