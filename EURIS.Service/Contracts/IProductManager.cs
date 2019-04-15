using EURIS.Entities.Models;
using System.Collections.Generic;

namespace EURIS.Service.Contracts
{
    public interface IProductManager
    {
        List<Product> GetProducts();
        Product GetProduct(int? id);
        void AddProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
    }
}
