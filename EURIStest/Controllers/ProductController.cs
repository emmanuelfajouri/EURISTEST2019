using EURIS.Entities.Models;
using EURIS.Service.Contracts;
using EURISTest.Models;
using System.Net;
using System.Web.Mvc;

namespace EURISTest.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductManager productManager;

        public ProductController(IProductManager _productManager)
        {
            productManager = _productManager;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(productManager.GetProducts());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                productManager.AddProduct(MapCatalogViewModel(product));
                return RedirectToAction("Index");
            }

            return View(product);
        }

        private Product MapCatalogViewModel(ProductViewModel productvm)
        {
            return new Product
            {
                Code = productvm.Code,
                Description = productvm.Description,
                Id = productvm.Id,
            };
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                productManager.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productManager.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
