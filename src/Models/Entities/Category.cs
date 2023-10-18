using src.Models.DTO.CategoryDTOS;

namespace src.Models.Entities
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public List<Product> Products { get; set; } = new();

		public Category(int categoryID, string name)
		{
			CategoryID = categoryID;
			Name = name;
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
			Name = model.Name;
		}
	}
}