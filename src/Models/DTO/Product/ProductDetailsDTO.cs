namespace src.Models.DTO.Product
{
	public class ProductDetailsDTO
    {
        public int ProductID { get; set; }
		public string Name { get; set; }
		public string Version { get; set; }
		public string Category { get; set; }

		public ProductDetailsDTO(int productID, string name, string version, string category)
		{
			Version = version;
			Category = category;
		}

		public ProductDetailsDTO()
		{
		}
	}
}