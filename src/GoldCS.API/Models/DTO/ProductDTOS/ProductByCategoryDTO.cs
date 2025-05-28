using src.Models.Entities;

namespace src.Models.DTO.ProductDTOS
{
	public class ProductByCategoryDTO
    {
        public int ProductID { get; set; }
		public string Name { get; set; }
		public string Version { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public ProductByCategoryDTO(int productID, string name, string version, int quantity, decimal price)
		{
			ProductID = productID;
			Name = name;
			Version = version;
			Price = price;
			Quantity = quantity;
		}

		public ProductByCategoryDTO()
		{
		}

		public ProductByCategoryDTO(Product model)
		{
			ProductID = model.ProductID;
			Name = model.Name;
			Version = model.Version;
			Price = model.Price;
			Quantity = model.Quantity;
		}
	}
}