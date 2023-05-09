namespace src.Models.DTO.Amount
{
	public class AmountInsertDTO
    {
        public int Quantity { get; set; }
		public double Price { get; set; }
		public int ProductID { get; set; }

		public AmountInsertDTO(int quantity, double price, int productID)
		{
			Quantity = quantity;
			Price = price;
			ProductID = productID;
		}

		public AmountInsertDTO()
		{
		}
	}
}