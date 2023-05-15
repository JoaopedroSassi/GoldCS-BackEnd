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
	}
}