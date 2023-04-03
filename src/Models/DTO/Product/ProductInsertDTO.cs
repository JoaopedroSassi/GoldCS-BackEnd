namespace src.Models.DTO.Product
{
	public class ProductInsertDTO
    {
        public string Name { get; set; }
		public int CategoryID { get; set; }

		public ProductInsertDTO(string name, int categoryID)
		{
			Name = name;
			CategoryID = categoryID;
		}

		public ProductInsertDTO()
		{
		}
	}
}