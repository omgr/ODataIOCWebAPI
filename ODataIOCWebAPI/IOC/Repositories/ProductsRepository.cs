using ODataIOCWebAPI.IOC.IRepositories;
using ODataIOCWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;

namespace ODataIOCWebAPI.IOC.Repositories
{
    public class ProductsRepository :IProductsRepository
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private DBContext db = new DBContext();

        public bool ProductExists(int key)
        {
            return db.Products.Any(p => p.Id == key);
        }

        public IQueryable<Product> GetAll() {
            logger.Debug("Getting all products called from Productsrepositor");
            return db.Products;
        }

        public Product Add(Product product)
        {
            
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }
    }
}