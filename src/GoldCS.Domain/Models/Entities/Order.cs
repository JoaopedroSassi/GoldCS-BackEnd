using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Util;

namespace GoldCS.Domain.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string UserName { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Subtotal { get; set; }
        public string PaymentMethod { get; set; }
        public int ClientId { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public Client Client { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }

        public Order() { }
        
        public Order(OrderRequests.CreateOrder request)
        {
            CreatedAt = DateTime.Now;
            DeliveryDate = request.DeliveryDate;
            UserName = request.UserName;
            Status = OrderStatus.Received;
            PaymentMethod = request.PaymentMethod;
        }

    }
}
