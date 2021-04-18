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

        /// <summary>
        /// Test product with code "Code2"
        /// </summary>
        public static Product TestProduct2 => new Product()
        {
            Code = "Code2", Name = "Product 2", Price = 150m
        };

        /// <summary>
        /// Test order 
        /// </summary>
        public static Order TestOrder1 => new Order()
        {
            CustomerName = "CustomerJmeno CustomerPrijmeni", 
            CustomerPostAddress = "Adresa customer",
        };

        public static Order TestOrder2 => new Order()
        {
            CustomerName = "Customer2",
            CustomerPostAddress = "PostAddress2",
        };
    }
}
