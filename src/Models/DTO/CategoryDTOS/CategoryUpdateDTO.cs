namespace src.Models.DTO.CategoryDTOS
{
	public class CategoryUpdateDTO
    {
		public int CategoryID { get; set; }
		public string Name { get; set; }

		public CategoryUpdateDTO(string name, int categoryID)
		{
			Name = name;
			CategoryID = categoryID;
		}

		public CategoryUpdateDTO()
		{
		}
    }
}