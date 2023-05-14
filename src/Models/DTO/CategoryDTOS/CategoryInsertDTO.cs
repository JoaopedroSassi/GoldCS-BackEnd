namespace src.Models.DTO.CategoryDTOS
{
	public class CategoryInsertDTO
    {
		public string Name { get; set; }

		public CategoryInsertDTO(string name)
		{
			Name = name;
		}

		public CategoryInsertDTO()
		{
		}
	}
}