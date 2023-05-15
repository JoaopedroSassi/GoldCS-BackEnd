namespace src.Models.DTO.ProductDTOS
{
	public class ProductUpdateDTO
    {
		public int ProductID { get; set; }
        public string Name { get; set; }
		public string Version { get; set; }
		public decimal Price { get; set; }
		public int CategoryID { get; set; }

		public ProductUpdateDTO()
		{
		}

		public ProductUpdateDTO(int productID, string name, string version, decimal price, int categoryID)
		{
			ProductID = productID;
			Name = name;
			Version = version;
			Price = price;
			CategoryID = categoryID;
		}
	}
}