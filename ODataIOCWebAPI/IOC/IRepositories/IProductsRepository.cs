using ODataIOCWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataIOCWebAPI.IOC.IRepositories
{
    public interface IProductsRepository
    {
        bool ProductExists(int k);
        IQueryable<Product> GetAll();

        Product Add(Product product);
    }
}
