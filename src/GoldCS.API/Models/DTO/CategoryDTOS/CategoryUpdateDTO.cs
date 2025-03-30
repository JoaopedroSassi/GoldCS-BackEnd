namespace src.Models.DTO.CategoryDTOS
{
	public class CategoryUpdateDTO
    {
		public string Name { get; set; }

		public CategoryUpdateDTO(string name, int categoryID)
		{
			Name = name;
		}

		public CategoryUpdateDTO()
		{
		}
    }
}