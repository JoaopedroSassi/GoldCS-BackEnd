namespace src.Models.DTO.ProductDTOS
{
	public class ProductDetailsDTO
    {
        public int ProductID { get; set; }
		public string Name { get; set; }
		public string Version { get; set; }
		public string CategoryName { get; set; }

		public ProductDetailsDTO(int productID, string name, string version, string categoryName)
		{
			ProductID = productID;
			Name = name;
			Version = version;
			CategoryName = categoryName;
		}

		public ProductDetailsDTO()
		{
		}
	}
}