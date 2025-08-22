using GoldCS.Domain.Util;

namespace GoldCS.Domain.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string UserName { get; set; }
        public Client Client { get; set; }
        public OrderStatus Status { get; set; }
        public Adress Adress { get; set; }
        public decimal Subtotal { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }
    }
}
