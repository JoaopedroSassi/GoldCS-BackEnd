namespace src.Models.DTO.Category
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