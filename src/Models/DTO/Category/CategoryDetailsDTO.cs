using src.Models.DTO.Product;

namespace src.Models.DTO.Category
{
	public class CategoryDetailsDTO
    {
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public List<ProductDetailsDTO> Products {get; set;} = new();

		public CategoryDetailsDTO(int categoryID, string name, List<ProductDetailsDTO> products)
		{
			CategoryID = categoryID;
			Name = name;
			Products = products;
		}

		public CategoryDetailsDTO()
		{
		}
	}
}