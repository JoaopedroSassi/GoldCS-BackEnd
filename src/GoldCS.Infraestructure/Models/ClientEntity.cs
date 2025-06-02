namespace GoldCS.Infraestructure.Models
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
