namespace src.Models.DTO.Product
{
	public class ProductUpdateDTO
    {
        public string Name { get; set; }
		public int CategoryID { get; set; }

		public ProductUpdateDTO(string name, int categoryID)
		{
			Name = name;
			CategoryID = categoryID;
		}

		public ProductUpdateDTO()
		{
		}
	}
}