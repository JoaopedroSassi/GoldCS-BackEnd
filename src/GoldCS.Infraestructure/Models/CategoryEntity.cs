
namespace GoldCS.Infraestructure.Models
{
    public class CategoryEntity
    {
        public CategoryEntity() 
        {
            ProductsEntity = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductEntity> ProductsEntity { get; set; }
    }
}
