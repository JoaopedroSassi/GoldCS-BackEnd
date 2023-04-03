namespace src.Models.Entities
{
	public class Product
    {
		public int ProductID { get; set; }
		public string Name { get; set; }
		public Category Category { get; set; }
		public int CategoryID { get; set; }

		public Product(int productID, string name, Category category, int categoryID)
		{
			ProductID = productID;
			Name = name;
			Category = category;
			CategoryID = categoryID;
		}

		public Product()
		{
		}
	}
}