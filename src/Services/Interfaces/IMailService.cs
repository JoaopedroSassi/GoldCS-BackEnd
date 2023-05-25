using src.Models.DTO.MailDTOS;

namespace src.Services.Interfaces
{
	public interface IMailService
    {
        void SendEmail(MailSendDTO model);
    }
}