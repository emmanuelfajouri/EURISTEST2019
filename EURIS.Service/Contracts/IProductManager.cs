using EURIS.Entities.Models;
using System.Collections.Generic;

namespace EURIS.Service.Contracts
{
    public interface IProductManager
    {
        List<Product> GetProducts();
    }
}
