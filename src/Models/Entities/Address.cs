namespace src.Models.Entities
{
	public class Address
    {
        public int AddressID { get; set; }
		public string Cep { get; set; }
		public string AddressName { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string UF { get; set; }
		public string Number { get; set; }
		public string Complement { get; set; }
		public List<Order> Orders { get; set; } = new ();

		public Address(int addressID, string cep, string addressName, string city, string district, string uF, string number, string complement)
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

		public Address(string cep, string addressName, string city, string district, string uF, string number, string complement)
		{
			Cep = cep;
			AddressName = addressName;
			City = city;
			District = district;
			UF = uF;
			Number = number;
			Complement = complement;
		}

		public Address()
		{
		}
	}
}