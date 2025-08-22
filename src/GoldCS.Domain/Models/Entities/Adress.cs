using GoldCS.Domain.Util;

namespace GoldCS.Domain.Models.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public AdressType AdressType { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
    }
}
