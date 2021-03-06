﻿using EURIS.Entities.Models;
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
        Catalog GetCatalog(string code);
        void AddCatalog(Catalog catalog);
        void DeleteCatalog(string code);
        void UpdateCatalog(Catalog catalog);
    }
    
}
