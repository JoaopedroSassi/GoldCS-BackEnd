using src.Models.Entities;

namespace src.Models.DTO.ProductDTOS
{
	public class ProductAmountInsertDTO
	{
		public int ProductID { get; set; }
		public int Quantity { get; set; }

		public ProductAmountInsertDTO()
		{
		}

		public ProductAmountInsertDTO(int productID, int quantity)
		{
			ProductID = productID;
			Quantity = quantity;
		}
		
		public ProductAmountInsertDTO(OrderProduct model)
		{
			ProductID = model.ProductID;
			Quantity = model.Quantity;
		}
	}
}