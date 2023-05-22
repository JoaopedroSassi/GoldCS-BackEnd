using src.Models.DTO.CategoryDTOS;

namespace src.Models.Entities
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public List<Product> Products { get; set; } = new();

		public Category(int categoryID, string name, List<Product> products)
		{
			CategoryID = categoryID;
			Name = name;
			Products = products;
		}

		public Category()
		{
		}

		public Category(CategoryInsertDTO model)
		{
			Name = model.Name;
		}

		public Category(CategoryUpdateDTO model)
		{
			CategoryID = model.CategoryID;
			Name = model.Name;
		}
	}
}