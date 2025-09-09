namespace src.Models.DTO.OrderProductDTOS
{
	public class OrderProductInsertDTO
    {
        public int ProductID { get; set; }
		public int Quantity { get; set; }
		public decimal FinalPrice { get; set; }

		public OrderProductInsertDTO(int productID, int quantity, decimal finalPrice)
		{
			ProductID = productID;
			Quantity = quantity;
			FinalPrice = finalPrice;
		}

		public OrderProductInsertDTO()
		{
		}
	}
}