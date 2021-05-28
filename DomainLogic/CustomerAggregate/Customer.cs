using Domain.OrderAggregate;
using Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain.CustomerAggregate
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public string Email { get; private set; }
        public ICollection<Order> Orders { get; private set; }

        public Customer(string FirstName, string LastName, string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
        }

        private Customer(){}

        public Order CreateOrder(Dictionary<Product, int> productAndQuantity)
        {
            return new Order(this, productAndQuantity);
        }

        public Order GetOrder(int orderId)
        {
            return Orders.FirstOrDefault(_ => _.OrderId == orderId);
        }
    }
}
