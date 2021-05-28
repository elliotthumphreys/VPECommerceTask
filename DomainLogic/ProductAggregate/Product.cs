using Domain.OrderProductAggregate;
using Domain.ProductMetaDataAggregate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.ProductAggregate
{
    public class Product
    {
        public int ProductId { get; private set; }
        [Required]
        public decimal CostPerItem { get; private set; }
        [Required]
        public int StockCount { get; private set; }
        [Required]
        public string Name { get; private set; }
        public ICollection<ProductMetaData> MetaData { get; private set; }
        public ICollection<OrderProduct> OrderProducts { get; private set; }

        public Product(decimal CostPerItem, int StockCount, string Name, Dictionary<string, string> metaData)
        {
            this.CostPerItem = CostPerItem;
            this.StockCount = StockCount;
            this.Name = Name;

            if (metaData is null || metaData.Count == 0)
                return;

            MetaData = new List<ProductMetaData>();
            foreach (var dataEntry in metaData)
            {
                MetaData.Add(new ProductMetaData(dataEntry.Key, dataEntry.Value, this));
            }
        }

        private Product() { }
    }
}
