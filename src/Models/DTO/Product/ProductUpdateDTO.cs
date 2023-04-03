using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models.DTO.Product
{
    public class ProductUpdateDTO
    {
        public string Name { get; set; }

		public ProductUpdateDTO(string name)
		{
			Name = name;
		}

		public ProductUpdateDTO()
		{
		}
	}
}