using Shapping.DTO;
using Shapping.DTO.Merchant;
using Shapping.DTO.RegestarDto;

namespace Shapping.Handler.Marchant
{
    public interface IMerchantHandler
    {
        public Task<List<GetAllMerchantsDto>> GetAllMarchentsAsync();
        Task<int> RegisterMerchant(MerchantRegesterDTO registrationDTO);
        Task<int> UpdateMerchantPassword(UpdatePasswordDtos updatePassDto);
        Task<int> UpdateMerchant(MerchantUpdateDto updateDto);
        Task<int> DeleteMerchant(string userId);
        Task<MerchantUpdateDto> GetMerchantByIdWithSpecialPrices(string merchantId);
    }
}
