namespace src.Models.Entities
{
	public class OrderProduct
    {
        public Order Order { get; set; }
		public int OrderID { get; set; }
		public Product Product { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public decimal FinalPrice { get; set; }

		public OrderProduct(Order order, int orderID, Product product, int productID, int quantity, decimal finalPrice)
		{
			Order = order;
			OrderID = orderID;
			Product = product;
			ProductID = productID;
			Quantity = quantity;
			FinalPrice = finalPrice;
		}

		public OrderProduct()
		{
		}
	}
}