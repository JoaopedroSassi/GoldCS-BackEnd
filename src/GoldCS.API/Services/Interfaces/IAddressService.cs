using src.Models.DTO.AddressDTOS;

namespace src.Services.Interfaces
{
	public interface IAddressService
    {
        Task InsertAddressAsync(AddressInsertDTO model);
		Task DeleteAddressAsync(int id);
		Task UpdateAddressAsync(AddressUpdateDTO model);
    }
}