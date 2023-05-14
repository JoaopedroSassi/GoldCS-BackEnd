using src.Models.DTO.AmountDTOS;

namespace src.Services.Interfaces
{
	public interface IAmountService
    {
        Task InsertAmountAsync(AmountInsertDTO model);
    }
}