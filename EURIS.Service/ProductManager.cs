using EURIS.Data.Contracts;
using EURIS.Entities.Models;
using EURIS.Service.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EURIS.Service
{
    public class ProductManager: IProductManager
    {
        private readonly IUnitOfWork _uow;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List<Product> GetProducts()
        {
            return _uow.ProductRepository.GetAll().ToList();
        }
    }
}
