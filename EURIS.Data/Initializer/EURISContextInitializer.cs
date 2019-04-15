using EURIS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EURIS.Data.Initializer
{
    public class EURISContextInitializer : DropCreateDatabaseAlways<EURISContext>
    {
        protected override void Seed(EURISContext context)
        {
            try
            {

                var products = new List<Product>
                {
                    new Product  {Id = 1, Code = "prod1" , Description = "prod1"},
                    new Product  {Id = 2, Code = "prod2" , Description = "prod2"},
                    new Product  {Id = 3, Code = "prod3" , Description = "prod3"}

                }.ToList();

                new[]
                {
                      new Catalog  {Id = 1, Description = "catalog1", Code = "catalog1", Products = products.Take(1).ToList()},
                      new Catalog  {Id = 2, Description = "catalog2", Code = "catalog2", Products = products.Take(2).ToList()},
                      new Catalog  {Id = 3, Description = "catalog3", Code = "catalog3", Products = products.Take(3).ToList()}
                }.ToList().ForEach(x => context.Catalogs.Add(x));

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


    