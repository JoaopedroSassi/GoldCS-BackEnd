using src.Models.DTO.MailDTOS;
using src.Models.DTO.OrderDTOS;

namespace src.Services.Interfaces
{
	public interface IMailService
    {
        void SendEmail(OrderDetailsDTO order);
    }
}