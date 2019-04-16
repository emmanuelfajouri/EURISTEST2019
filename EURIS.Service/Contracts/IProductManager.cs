using EURIS.Entities.Models;
using System;
using System.Collections.Generic;

namespace EURIS.Service.Contracts
{
    public interface IProductManager
    {
        List<Product> GetProducts();
        List<Product> GetProducts(Func<Product, bool> where);
        Product GetProduct(string code);
        void AddProduct(Product product);
        void DeleteProduct(string code);
        void UpdateProduct(Product product);
    }
}
