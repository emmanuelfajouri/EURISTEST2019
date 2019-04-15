using System.Collections.Generic;
using System.Web.Mvc;

namespace EURISTest.Models
{
    public class CatalogViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<SelectListItem> Products { get; set; }
        public List<string> SelectedProducts { get; set; }
    }
}