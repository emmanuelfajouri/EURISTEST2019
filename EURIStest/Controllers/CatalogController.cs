using EURIS.Entities.Models;
using EURIS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            //_manifiestoService.SaveDisconnected(manifiesto);
            var catalogs = catalogManager.GetCatalogs();
            return View("Catalogs", catalogs);
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Catalog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalog/Create
        [HttpPost]
        public ActionResult Create(Catalog collection)
        {
            try
            {
                var catalog = new Catalog();
                catalog.Code = collection.Code;
                 
                // TODO: Add insert logic here
                //var catalogs = catalogManager.Save;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catalog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catalog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
