using EURIS.Entities.Models;
using System;
using System.Collections.Generic;

namespace EURIS.Service.Contracts
{
    public interface IProductManager
    {
        List<Product> GetProducts();
        List<Product> GetProducts(Func<Product, bool> where);
        Product GetProduct(int? id);
        void AddProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
    }
}
