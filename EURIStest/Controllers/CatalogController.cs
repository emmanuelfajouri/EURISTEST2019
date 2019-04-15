using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EURIS.Data;
using EURIS.Entities.Models;
using EURIS.Service.Contracts;

namespace EURISTest.Controllers
{
    public class CatalogController : Controller
    {

        private readonly ICatalogManager catalogManager;

        public CatalogController(ICatalogManager _catalogManager)
        {
            catalogManager = _catalogManager;
        }

        // GET: Catalog
        public ActionResult Index()
        {
            return View(catalogManager.GetCatalogs());
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int? id)
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

      
        // GET: Catalog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Description")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                catalogManager.AddCatalog(catalog);
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
            Catalog catalog = catalogManager.GetCatalog(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

     

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Description")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                catalogManager.UpdateCatalog(catalog);
                return RedirectToAction("Index");
            }
            return View(catalog);
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
