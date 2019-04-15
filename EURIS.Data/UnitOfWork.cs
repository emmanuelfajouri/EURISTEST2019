using EURIS.Data.Contracts;
using EURIS.Data.Repositories;
using EURIS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Product> productRepository;
        private IRepository<Catalog> catalogRepository;
        private readonly IEURISContext _context;

        public UnitOfWork()
        {
            
            _context = new EURISContext();
        }

        public IRepository<Product> ProductRepository
        {
            get { return productRepository ?? (productRepository = new ProductRepository(_context)); }
        }

        public IRepository<Catalog> CatalogRepository
        {
            get { return catalogRepository ?? (catalogRepository = new CatalogRepository(_context)); }
        }

        public void save()
        {
            _context.Save();
        }

    }
}
