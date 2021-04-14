using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CivopApp.Domain;

namespace CivopApp.Core
{
    /// <summary>
    /// Main database context 
    /// </summary>
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
