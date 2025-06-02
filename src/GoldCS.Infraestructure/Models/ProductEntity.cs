
using GoldCS.Infraestructure.Models;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Height { get; set; }
    public decimal Width { get; set; }
    public string MeasureType { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public virtual CategoryEntity CategoryNavigation { get; set; }
}