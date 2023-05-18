namespace src.Entities.DTO.ClientDTOS
{
	public class ClientInsertDTO
	{
		public int? Id { get; set;}
		public string Cpf { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string CellPhone { get; set; }
		public string LandlinePhone { get; set; }

		public ClientInsertDTO(string cpf, string name, string email, string cellPhone, string landlinePhone)
		{
			Cpf = cpf;
			Name = name;
			Email = email;
			CellPhone = cellPhone;
			LandlinePhone = landlinePhone;
		}

		public ClientInsertDTO()
		{
		}
	}
}