using EURIS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.Service.Contracts
{
    public interface ICatalogManager
    {
        List<Catalog> GetCatalogs();
        Catalog GetCatalog(int? id);
        void AddCatalog(Catalog catalog);
        void DeleteCatalog(int id);
        void UpdateCatalog(Catalog catalog);
    }
    
}
