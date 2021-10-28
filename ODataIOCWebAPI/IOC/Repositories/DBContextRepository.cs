using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ODataIOCWebAPI.IOC.IRepositories;
using ODataIOCWebAPI.Models;

namespace ODataIOCWebAPI.IOC.Repositories
{
    public class DBContextRepository : IDbContextRepository
    {
        public DBContext GetDBContext()
        {
            return new DBContext();
        }
    }
}