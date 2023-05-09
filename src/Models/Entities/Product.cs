namespace src.Models.Entities
{
	public class Product
    {
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Version { get; set; }
		public Category Category { get; set; }
		public int CategoryID { get; set; }
		public List<Amount> Amounts { get; set; }

		public Product(int productID, string name, string version, Category category, int categoryID)
		{
			ProductID = productID;
			Name = name;
			Version = version;
			Category = category;
			CategoryID = categoryID;
		}

		public Product()
		{
		}
	}
}