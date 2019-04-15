using EURIS.Entities.Models;
using EURIS.Service.Contracts;
using EURISTest.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EURISTest.Controllers
{
    public class CatalogController : Controller
    {

        private readonly ICatalogManager catalogManager;
        private readonly IProductManager productManager;

        public CatalogController(ICatalogManager _catalogManager, IProductManager _productManager)
        {
            catalogManager = _catalogManager;
            productManager = _productManager;

        }

        // GET: Catalog
        public ActionResult Index()
        {
            var catalogsVM = new List<CatalogViewModel>();
            foreach (var item in catalogManager.GetCatalogs())
            {
                catalogsVM.Add(MapCatalog(item));
            }
            return View(catalogsVM);
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var catalog = GetCatalogViewModel(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

      
        // GET: Catalog/Create
        public ActionResult Create()
        {
            var newCatalog = new CatalogViewModel
            {
                Products = productManager.GetProducts().Select(x => new SelectListItem() { Text = x.Description, Value = x.Code }).ToList()
            };
            return View(newCatalog);
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatalogViewModel catalog)
        {
            if (ModelState.IsValid)
            {
                catalogManager.AddCatalog(MapCatalogViewModel(catalog));
                return RedirectToAction("Index");
            }

            return View(catalog);
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var catalogvm = GetCatalogViewModel(id);

            if (catalogvm == null)
            {
                return HttpNotFound();
            }
            return View(catalogvm);
        }

        private CatalogViewModel GetCatalogViewModel(int? id)
        {
            var catalog = catalogManager.GetCatalog(id);

            if (catalog == null)
                return null;

            CatalogViewModel catalogvm = MapCatalog(catalog);

            return catalogvm;
        }

        private CatalogViewModel MapCatalog(Catalog catalog)
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

        private Catalog MapCatalogViewModel(CatalogViewModel catalogvm)
        {
            return new Catalog
            {
                Code = catalogvm.Code,
                Description = catalogvm.Description,
                Id = catalogvm.Id,
                Products = productManager.GetProducts(x => catalogvm.SelectedProducts.Contains(x.Code)).ToList()
            };
        }



        // POST: Catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CatalogViewModel catalogviewmodel)
        {
            if (ModelState.IsValid)
            {
                var old = catalogManager.GetCatalog(catalogviewmodel.Id);

                if (old == null)
                {
                    return HttpNotFound();
                }

                old.Code = catalogviewmodel.Code;
                old.Description = catalogviewmodel.Description;
                old.Products.Clear();
                old.Products = productManager.GetProducts(x=> catalogviewmodel.SelectedProducts.Contains(x.Code));
                
                catalogManager.UpdateCatalog(old);
                return RedirectToAction("Index");
            }
            return View(catalogviewmodel);
        }

       

        // GET: Catalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = catalogManager.GetCatalog(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            catalogManager.DeleteCatalog(id);
            return RedirectToAction("Index");
        }
       
    }
}
