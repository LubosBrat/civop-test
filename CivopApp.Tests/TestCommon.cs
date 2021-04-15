using CivopApp.Domain;

namespace CivopApp.Tests
{
    public static class TestCommon
    {
        /// <summary>
        /// Test product with Code "Code1"
        /// </summary>
        public static Product TestProduct1 => new Product()
        {
            Code = "Code1", Name = "Product 1", Price = 10m
        };
    }
}
