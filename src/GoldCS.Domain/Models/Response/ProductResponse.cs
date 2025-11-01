namespace GoldCS.Domain.Models.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public string MeasureType { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public bool Active { get; set; } = true;
        public DateTime InclusionDate { get; set; }
    }
}
