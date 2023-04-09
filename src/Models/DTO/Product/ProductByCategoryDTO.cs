namespace src.Models.DTO.Product
{
	public class ProductByCategoryDTO
    {
        public int ProductID { get; set; }
		public string Name { get; set; }
		public string Version { get; set; }

		public ProductByCategoryDTO(int productID, string name, string version)
		{
			ProductID = productID;
			Name = name;
			Version = version;
		}

		public ProductByCategoryDTO()
		{
		}
	}
}