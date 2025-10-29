namespace GoldCS.Domain.Models.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitaryValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }

    }
}
