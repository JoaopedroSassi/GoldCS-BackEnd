using System.Net;
using System.Net.Mail;
using src.Models.DTO.MailDTOS;
using src.Models.DTO.OrderDTOS;
using src.Models.Entities;
using src.Services.Interfaces;

namespace src.Services
{
	public class MailService : IMailService
	{
		private readonly IConfiguration _configuration;

		public MailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

        public void SendEmail(OrderDetailsDTO order)
		{
			using (MailMessage mailMessage = new MailMessage())
			{
				mailMessage.From = new MailAddress(_configuration["Email:Email"]);
				mailMessage.To.Add(order.Client.Email);
				mailMessage.Subject = "Venda - Gold Colchões";
				//mailMessage.Attachments.Add(new Attachment(model.Document.OpenReadStream(), $"Pedido N°{model.OrderID}.pdf"));
				mailMessage.Body = "Olá, obrigado por ter feito uma compra conosco! Segue abaixo uma cópia do seu pedido.";
				mailMessage.Body = order.ToString();
				mailMessage.IsBodyHtml = false;
				using (SmtpClient smtp = new SmtpClient(_configuration["Email:SmtpAddress"], Convert.ToInt32(_configuration["Email:Port"])))
				{
					smtp.EnableSsl = true;
					smtp.UseDefaultCredentials = false;
					smtp.Credentials = new NetworkCredential(_configuration["Email:Email"], _configuration["Email:Password"]);
					smtp.Send(mailMessage);
				}
			}
		}
	}
}