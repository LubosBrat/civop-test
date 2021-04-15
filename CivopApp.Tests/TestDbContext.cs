using System.Linq;
using CivopApp.Core;

namespace CivopApp.Tests
{
    public class TestDbContext
    {
        private static IAppDbContext _instance;

        public static IAppDbContext Instance => _instance ?? (_instance = new AppDbContext());

        public static void ClearData()
        {
            Instance.OrderProducts.RemoveRange(Instance.OrderProducts.ToList());
            Instance.Products.RemoveRange(Instance.Products.ToList());
            Instance.Orders.RemoveRange(Instance.Orders.ToList());
        }
    }
}
