namespace src.Models.DTO.Product
{
	public class ProductDetailsDTO
    {
        public int ProductID { get; set; }
		public string Name { get; set; }

		public ProductDetailsDTO(int productID, string name)
		{
			ProductID = productID;
			Name = name;
		}

		public ProductDetailsDTO()
		{
		}
	}
}