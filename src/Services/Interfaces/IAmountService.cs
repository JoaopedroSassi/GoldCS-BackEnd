using src.Models.DTO.Amount;

namespace src.Services.Interfaces
{
	public interface IAmountService
    {
        Task InsertAmountAsync(AmountInsertDTO model);
    }
}