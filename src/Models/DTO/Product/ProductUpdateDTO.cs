namespace src.Models.DTO.Product
{
	public class ProductUpdateDTO
    {
		public int ProductID { get; set; }
        public string Name { get; set; }
		public string Version { get; set; }
		public int CategoryID { get; set; }

		public ProductUpdateDTO(int productID, string name, string version, int categoryID)
		{
			ProductID = productID;
			Name = name;
			Version = version;
			CategoryID = categoryID;
		}

		public ProductUpdateDTO()
		{
		}
	}
}