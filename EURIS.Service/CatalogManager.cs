using EURIS.Data.Contracts;
using EURIS.Entities.Models;
using EURIS.Service.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EURIS.Service
{
    public class CatalogManager: ICatalogManager
    {
        private readonly IUnitOfWork _uow;

        public CatalogManager(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List<Catalog> GetCatalogs()
        {
            return _uow.CatalogRepository.GetAll().ToList();
        }

        public Catalog GetCatalog(string code)
        {
            return _uow.CatalogRepository.Find(x=> x.Code == code).FirstOrDefault();
        }

        public void AddCatalog(Catalog catalog)
        {
            _uow.CatalogRepository.Add(catalog);
            _uow.SaveChanges();
        }

        public void DeleteCatalog(string code)
        {
            Catalog catalog = GetCatalog(code);
            _uow.CatalogRepository.Remove(catalog);
            _uow.SaveChanges();
        }

        public void UpdateCatalog(Catalog catalog)
        {
            _uow.CatalogRepository.Update(catalog);
            _uow.SaveChanges();
        }
    }
}
