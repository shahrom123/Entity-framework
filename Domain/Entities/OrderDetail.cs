
namespace Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } 
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public OrderDetail()
        {

        }
        public OrderDetail(int id, int quantity, int orderId, int productId)
        {
            Id = id;
            Quantity = quantity;
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
