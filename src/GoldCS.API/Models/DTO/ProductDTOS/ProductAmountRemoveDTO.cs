using src.Models.DTO.OrderProductDTOS;

namespace src.Models.DTO.ProductDTOS
{
	public class ProductAmountRemoveDTO
    {
        public int ProductID { get; set; }
		public int Quantity { get; set; }

		public ProductAmountRemoveDTO()
		{
		}

		public ProductAmountRemoveDTO(int productID, int quantity)
		{
			ProductID = productID;
			Quantity = quantity;
		}

		public ProductAmountRemoveDTO(OrderProductInsertDTO model)
		{
			ProductID = model.ProductID;
			Quantity = model.Quantity;
		}
	}
}