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

        public void Save(Catalog catalog)
        {
            
                _uow.CatalogRepository.Add(catalog);

            //_uow.CatalogRepository.save();
        }
    }
}
