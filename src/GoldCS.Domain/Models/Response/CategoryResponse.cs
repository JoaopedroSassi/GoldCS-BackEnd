namespace GoldCS.Domain.Models.Response
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } 
        public DateTime InclusionDate { get; set; }
    }
}
