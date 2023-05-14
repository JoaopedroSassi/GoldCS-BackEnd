using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models.Entities;

namespace src.Models.DTO.OrderProductDTOS
{
    public class OrderProductDetailsDTO
    {
        public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal FinalPrice { get; set; }

		public OrderProductDetailsDTO()
		{
		}

		public OrderProductDetailsDTO(string productName, int quantity, decimal finalPrice)
		{
			ProductName = productName;
			Quantity = quantity;
			FinalPrice = finalPrice;
		}

		public OrderProductDetailsDTO(OrderProduct model)
		{
			ProductName = model.Product.Name;
			Quantity = model.Quantity;
			FinalPrice = model.FinalPrice;
		}
	}
}