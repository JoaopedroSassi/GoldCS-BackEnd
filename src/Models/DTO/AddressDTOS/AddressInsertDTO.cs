namespace src.Models.DTO.AddressDTOS
{
	public class AddressInsertDTO
    {
        public string Cep { get; set; }
		public string AddressName { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string UF { get; set; }
		public string Number { get; set; }
		public string Complement { get; set; }

		public AddressInsertDTO(string cep, string addressName, string city, string district, string uF, string number, string complement)
		{
			Cep = cep;
			AddressName = addressName;
			City = city;
			District = district;
			UF = uF;
			Number = number;
			Complement = complement;
		}

		public AddressInsertDTO(string cep, string addressName, string city, string district, string uF, string number)
		{
			Cep = cep;
			AddressName = addressName;
			City = city;
			District = district;
			UF = uF;
			Number = number;
			Complement = String.Empty;
		}

		public AddressInsertDTO()
		{
		}
	}
}