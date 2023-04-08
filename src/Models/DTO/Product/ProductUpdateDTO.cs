namespace src.Models.DTO.Product
{
	public class ProductUpdateDTO
    {
        public string Name { get; set; }
		public string Version { get; set; }
		public int CategoryID { get; set; }

		public ProductUpdateDTO(string name, string version, int categoryID)
		{
			Name = name;
			Version = version;
			CategoryID = categoryID;
		}

		public ProductUpdateDTO()
		{
		}
	}
}