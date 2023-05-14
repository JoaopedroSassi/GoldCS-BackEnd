namespace src.Models.DTO.ProductDTOS
{
	public class ProductInsertDTO
    {
        public string Name { get; set; }
		public string Version { get; set; }
		public int CategoryID { get; set; }

		public ProductInsertDTO(string name, string version, int categoryID)
		{
			Name = name;
			Version = version;
			CategoryID = categoryID;
		}

		public ProductInsertDTO()
		{
		}
	}
}