using Domain.CustomerAggregate;
using Domain.OrderProductAggregate;
using Domain.ProductAggregate;
using System;
using System.Collections.Generic;

namespace Domain.OrderAggregate
{
    public class Order
    {
        public int OrderId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public ICollection<OrderProduct> OrderProducts { get; private set; }

        public Order(Customer customer, Dictionary<Product, int> productIdAndQuantity)
        {
            this.OrderDate = DateTime.Now;
            this.Customer = customer;

            if (productIdAndQuantity is null || productIdAndQuantity.Count == 0)
                throw new Exception("An order must have products.");

            OrderProducts = new List<OrderProduct>();
            foreach (var dataEntry in productIdAndQuantity)
            {
                OrderProducts.Add(new OrderProduct(dataEntry.Value, this, dataEntry.Key));
            }
        }

        private Order() { }
    }
}
