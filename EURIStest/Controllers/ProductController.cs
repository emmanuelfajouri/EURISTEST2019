using EURIS.Entities.Models;
using EURIS.Service.Contracts;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EURISTest.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        private readonly IProductManager productManager;

        public ProductController(IProductManager _productManager)
        {
            productManager = _productManager;
        }

        public ActionResult Index()
        {
            List<Product> products = productManager.GetProducts();

            ViewBag.Products = products;

            return View();
        }

    }
}
