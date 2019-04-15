using System.Collections.Generic;

namespace EURIS.Entities.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
