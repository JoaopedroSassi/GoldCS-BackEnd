using src.Models.Entities;

namespace src.Models.DTO.ProductDTOS
{
	public class ProductDetailsDTO
    {
        public int ProductID { get; set; }
		public string Name { get; set; }
		public string Version { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public string CategoryName { get; set; }
		public int CategoryID { get; set; }

		public ProductDetailsDTO()
		{
		}

		public ProductDetailsDTO(int productID, string name, string version, int quantity, decimal price, string categoryName, int categoryID)
		{
			ProductID = productID;
			Name = name;
			Version = version;
			Quantity = quantity;
			Price = price;
			CategoryName = categoryName;
			CategoryID = categoryID;
		}

		public ProductDetailsDTO(Product model)
		{
			ProductID = model.ProductID;
			Name = model.Name;
			Version = model.Version;
			Quantity = model.Quantity;
			Price = model.Price;
			CategoryName = model.Category.Name;
			CategoryID = model.CategoryID;
		}
	}
}