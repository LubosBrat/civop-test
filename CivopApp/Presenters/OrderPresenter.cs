using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;
using CivopApp.Core;
using CivopApp.Domain;
using CivopApp.Views;

namespace CivopApp.Presenters
{
    public class OrderPresenter : PresenterBase
    {
        private readonly IOrderView _view;

        public OrderPresenter(IOrderView view, IAppDbContext dbContext) : base(dbContext)
        {
            _view = view;
        }

        /// <summary>
        /// Loads page content, order detail 
        /// </summary>
        public override void OnLoadPage()
        {
            _view.Title = "Detail objednávky";
            _view.AllProducts = DbContext.Products.ToList();
            if (string.IsNullOrEmpty(_view.OrderIdQs)) return;
            _view.OrderId = Convert.ToInt32(_view.OrderIdQs);
            var order = DbContext.Orders.Include("Products").FirstOrDefault(x => x.Id == _view.OrderId);
            if (order == null) return;

            _view.CustomerName = order.CustomerName;
            _view.CustomerPostAddress = order.CustomerPostAddress;
            _view.Products = order.Products.ToList();

            if (string.IsNullOrEmpty(_view.ProductIdQs)) return;
            _view.ProductId = Convert.ToInt32(_view.ProductIdQs);
            var product = order.Products.FirstOrDefault(x => x.ProductId == Convert.ToInt32(_view.ProductIdQs));
            _view.Quantity = product?.Quantity ?? 0;
        }

        /// <summary>
        /// Saves current new or existing order with new or existing product
        /// Returns id of the order
        /// </summary>
        public int SaveOrder()
        {
            var order = IsNewOrder
                ? new Order() 
                : DbContext.Orders.Include("Products").FirstOrDefault(x => x.Id == _view.OrderId);

            if (order == null)
                throw new ObjectNotFoundException("Objednávka nebyla nalezena v databázi");

            order.CustomerName = _view.CustomerName;
            order.CustomerPostAddress = _view.CustomerPostAddress;

            if (_view.ProductId != null) // order with OrderProduct
            {
                var product = DbContext.Products.Find(_view.ProductId);
                if (product != null && IsNewOrder) // new Order and new OrderProduct
                {
                    order.Products = new List<OrderProduct>() { new OrderProduct()  { Order = order, Product = product, Quantity = _view.Quantity, Price = product.Price } };
                    DbContext.Orders.AddOrUpdate(order);
                } else if (product != null && !IsNewOrder) // existing Order 
                {
                    var productOrder = order.Products.FirstOrDefault(x => x.ProductId == _view.ProductId);
                    if (productOrder != null) // existing Order and updating existing OrderProduct
                    {
                        productOrder.Quantity = _view.Quantity;
                        productOrder.Price = product.Price;
                        DbContext.OrderProducts.AddOrUpdate(productOrder);
                    }
                    else    // existing Order and adding new OrderProduct
                    {
                        order.Products.Add(new OrderProduct()
                        {
                            Order = order, 
                            Product = product,
                            Quantity = _view.Quantity,
                            Price = product.Price
                        });

                    }
                    DbContext.Orders.AddOrUpdate(order);
                }
            }
            else
            {
                DbContext.Orders.AddOrUpdate(order);
            }

            DbContext.SaveChanges();
            return order.Id;
        }


        /// <summary>
        /// Deletes order
        /// </summary>
        public void DeleteOrder()
        {
            
        }

        private bool IsNewOrder => _view.OrderId == null;
    }
}