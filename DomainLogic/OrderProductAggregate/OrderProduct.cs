using Domain.OrderAggregate;
using Domain.ProductAggregate;

namespace Domain.OrderProductAggregate
{
    public class OrderProduct
    {
        public int Quantity { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private  set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public OrderProduct(int Quantity, Order Order, Product Product)
        {
            this.Order = Order;
            this.Product = Product;
            this.Quantity = Quantity;
        }

        public OrderProduct() { }
    }
}
