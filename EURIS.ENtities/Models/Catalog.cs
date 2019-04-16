using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EURIS.Entities.Models
{
    public class Catalog
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual ICollection<ProductCatalog> ProductCatalogs { get; set; }
    }
}
