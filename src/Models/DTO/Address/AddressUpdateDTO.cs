namespace src.Models.DTO.Address
{
	public class AddressUpdateDTO
    {
        public int AddressID { get; set; }
		public string Cep { get; set; }
		public string AddressName { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string UF { get; set; }
		public string Number { get; set; }
		public string Complement { get; set; }

		public AddressUpdateDTO(int addressID, string cep, string addressName, string city, string district, string uF, string number, string complement)
		{
			AddressID = addressID;
			Cep = cep;
			AddressName = addressName;
			City = city;
			District = district;
			UF = uF;
			Number = number;
			Complement = complement;
		}

		public AddressUpdateDTO()
		{
		}
	}
}