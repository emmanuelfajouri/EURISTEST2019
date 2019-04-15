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

        public Product GetProduct(int? id)
        {
            return _uow.ProductRepository.Find(x => x.Id == id).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            _uow.ProductRepository.Add(product);
            _uow.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProduct(id);
            _uow.ProductRepository.Remove(product);
            _uow.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _uow.ProductRepository.Update(product);
            _uow.SaveChanges();
        }
    }
}
