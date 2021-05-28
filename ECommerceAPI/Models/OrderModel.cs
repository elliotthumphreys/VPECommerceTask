using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class OrderModel
    {
        [Required]
        [MinLength(1)]
        public IEnumerable<OrderItem> OrderItem { get; set; }
    }

    public class OrderItem
    {

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
