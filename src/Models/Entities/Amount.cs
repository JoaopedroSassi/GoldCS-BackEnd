namespace src.Models.Entities
{
	public class Amount
    {
        public int AmountID { get; set; }
		public DateTime AmountDate { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Product Product { get; set; }
		public int ProductID { get; set; }

		public Amount(int amountID, int quantity, decimal price, Product product, int productID)
		{
			AmountID = amountID;
			AmountDate = DateTime.Now;
			Quantity = quantity;
			Price = price;
			Product = product;
			ProductID = productID;
		}

		public Amount()
		{
		}
	}
}