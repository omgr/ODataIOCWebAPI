using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ODataIOCWebAPI.IOC.IRepositories;

namespace ODataIOCWebAPI.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=DBContext") { }

        public DbSet<Product> Products { get; set; }
    }
}