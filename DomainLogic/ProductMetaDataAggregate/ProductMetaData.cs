using Domain.ProductAggregate;

namespace Domain.ProductMetaDataAggregate
{
    public class ProductMetaData
    {
        public int ProductMetaDataId { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set;}

        public ProductMetaData(string Name, string Value, Product Product)
        {
            this.Name = Name;
            this.Value = Value;
            this.Product = Product;
        }

        private ProductMetaData() { }
    }
}
