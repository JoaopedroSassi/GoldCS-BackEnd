namespace src.Models.Entities
{
	public class Product
    {
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Version { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Category Category { get; set; }
		public int CategoryID { get; set; }
		public List<OrderProduct> OrderProducts { get; set; } = new ();

		public Product()
		{
		}

		public Product(int productID, string name, string version, int quantity, decimal price, Category category, int categoryID)
		{
			ProductID = productID;
			Name = name;
			Version = version;
			Quantity = quantity;
			Price = price;
			Category = category;
			CategoryID = categoryID;
		}
	}
}