using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models.Entities;

namespace src.Models.DTO.AddressDTOS
{
    public class AddressDetailsDTO
    {
        public int AddressID { get; set; }
		public string Cep { get; set; }
		public string AddressName { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string UF { get; set; }
		public string Number { get; set; }
		public string Complement { get; set; }

		public AddressDetailsDTO()
		{
		}
		
		public AddressDetailsDTO(int addressID, string cep, string addressName, string city, string district, string uF, string number, string complement)
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

		public AddressDetailsDTO(Address model)
		{
			AddressID = model.AddressID;
			Cep = model.Cep;
			AddressName = model.AddressName;
			City = model.City;
			District = model.District;
			UF = model.UF;
			Number = model.Number;
			Complement = model.Complement;
		}
	}
}