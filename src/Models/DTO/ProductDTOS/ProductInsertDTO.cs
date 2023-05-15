namespace src.Models.DTO.ProductDTOS
{
	public class ProductInsertDTO
    {
        public string Name { get; set; }
		public string Version { get; set; }
		public decimal Price { get; set; }
		public int CategoryID { get; set; }

		public ProductInsertDTO()
		{
		}

		public ProductInsertDTO(string name, string version, decimal price, int categoryID)
		{
			Name = name;
			Version = version;
			Price = price;
			CategoryID = categoryID;
		}
	}
}