namespace src.Models.DTO.Category
{
	public class CategoryDetailsDTO
    {
		public int CategoryID { get; set; }
		public string Name { get; set; }

		public CategoryDetailsDTO(int categoryID, string name)
		{
			CategoryID = categoryID;
			Name = name;
		}

		public CategoryDetailsDTO()
		{
		}
	}
}