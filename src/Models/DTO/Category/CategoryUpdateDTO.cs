namespace src.Models.DTO.Category
{
	public class CategoryUpdateDTO
    {
		public string Name { get; set; }

		public CategoryUpdateDTO(string name)
		{
			Name = name;
		}

		public CategoryUpdateDTO()
		{
		}
    }
}