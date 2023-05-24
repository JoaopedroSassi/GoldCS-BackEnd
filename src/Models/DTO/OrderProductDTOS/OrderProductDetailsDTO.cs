using src.Models.Entities;

namespace src.Models.DTO.OrderProductDTOS
{
	public class OrderProductDetailsDTO
    {
		public int ProductID { get; set; }
        public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal FinalPrice { get; set; }

		public OrderProductDetailsDTO()
		{
		}

		public OrderProductDetailsDTO(int productID, string productName, int quantity, decimal finalPrice)
		{
			ProductID = productID;
			ProductName = productName;
			Quantity = quantity;
			FinalPrice = finalPrice;
		}

		public OrderProductDetailsDTO(OrderProduct model)
		{
			ProductID = model.ProductID;
			ProductName = model.Product.Name;
			Quantity = model.Quantity;
			FinalPrice = model.FinalPrice;
		}
	}
}