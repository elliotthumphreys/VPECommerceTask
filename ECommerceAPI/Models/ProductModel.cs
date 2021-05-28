using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class ProductModel
    {
        [Required]
        public decimal CostPerItem { get; set; }
        [Required]
        public int StockCount { get; set; }
        [Required]
        public string Name { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
    }
}
