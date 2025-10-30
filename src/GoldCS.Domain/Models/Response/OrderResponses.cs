using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Util;

namespace GoldCS.Domain.Models.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public decimal Subtotal { get; set; }
        public string PaymentMethod { get; set; }
        public string AdressType { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientCpf { get; set; }
        public string ClientEmail { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public List<OrderProductsResponse> Products { get; set; }
    }

    public class OrderProductsResponse
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitaryValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }

    }
}
