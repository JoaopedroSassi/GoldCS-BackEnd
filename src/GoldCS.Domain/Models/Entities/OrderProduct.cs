namespace GoldCS.Domain.Models.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public double UnitaryValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }

    }
}
