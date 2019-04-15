using System.Collections.Generic;
using System.Web.Mvc;

namespace EURISTest.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<SelectListItem> Catalogs { get; set; }
    }
}