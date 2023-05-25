namespace src.Models.DTO.MailDTOS
{
	public class MailSendDTO
    {
		public int OrderID { get; set; }
        public string Email { get; set; }
		public IFormFile Document { get; set; }

		public MailSendDTO()
		{
		}

		public MailSendDTO(int orderID, string email, IFormFile document)
		{
			OrderID = orderID;
			Email = email;
			Document = document;
		}
	}
}