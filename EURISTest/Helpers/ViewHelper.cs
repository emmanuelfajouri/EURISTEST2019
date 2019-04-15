using EURIS.Entities.Models;
using EURIS.Service.Contracts;
using EURISTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EURISTest.Helpers
{
    public static class ViewHelper
    {
        public static CatalogViewModel MapCatalog(Catalog catalog, IProductManager productManager)
        {
            return new CatalogViewModel
            {
                Code = catalog.Code,
                Description = catalog.Description,
                Id = catalog.Id,
                SelectedProducts = catalog.Products.Select(x => x.Code).ToList(),
                Products = productManager.GetProducts().Select(x => new SelectListItem() { Text = x.Description, Value = x.Code }).ToList()
            };
        }
    }
}