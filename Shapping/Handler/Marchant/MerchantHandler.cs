using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shapping.DTO;
using Shapping.DTO.Merchant;
using Shapping.DTO.RegestarDto;
using Shapping.DTO.SpecailPrices;
using Shapping.Model;
using Shapping.Reprostary.Merchant;
using Shapping.Reprostary.SpecialPrice;
using System.Security.Claims;
using System.Threading;

namespace Shapping.Handler.Marchant
{
    public class MerchantHandler : IMerchantHandler
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ISpecialPriceRopresatry specialPricesRepository;
        private readonly IMerchantReprosatry reprosatry;

        public MerchantHandler(UserManager<AppUser> userManager, ISpecialPriceRopresatry specialPricesRepository, IMerchantReprosatry reprosatry)
        {
            this.userManager = userManager;
            this.specialPricesRepository = specialPricesRepository;
            this.reprosatry = reprosatry;
        }

        public async Task<int> DeleteMerchant(string userId)
        {
            var merchant = await reprosatry.GetMerchant(m => m.AppUser.Id == userId && !m.AppUser.IsDeleted);
            if (merchant == null)
            {
                return 0;
            }
            
            await specialPricesRepository.RemoveRangeAsync(merchant.SpecialPrices.ToList());
            merchant.AppUser.IsDeleted = true;
            await userManager.UpdateAsync(merchant.AppUser);

            await reprosatry.SaveChangesAsync();

            return merchant.MarchantId;
        }

        public async Task<MerchantUpdateDto> GetMerchantByIdWithSpecialPrices(string userId)
        {
            var merchant = await reprosatry.GetMerchant(m => m.AppUser.Id == userId && !m.AppUser.IsDeleted);


            if (merchant == null)
            {
                return null;
            }
            

            var merchantDto = new MerchantUpdateDto
            {
                Name = merchant.AppUser.Name,
                PhoneNumber = merchant.AppUser.PhoneNumber,
                Address = merchant.AppUser.Address,
                StoreName = merchant.StoreName,
                ReturnerPercent = (double)merchant.ReturnerPercent,
                BranchId = merchant.AppUser.BranchId,
                CityId = (int)merchant.CityId,
                GovernorateId = (int)merchant.GovernorateId,
                SpecialPrices = merchant.SpecialPrices?.Select(sp => new SpecialPricesDTO
                {
                    Price = sp.Price,
                    GovernorateId = sp.GovernorateId,
                    CityId = sp.CityId
                }).ToList() ?? new()
            };

            return merchantDto;
        }

        public async Task<int> RegisterMerchant(MerchantRegesterDTO registrationDTO)
        {

           
            AppUser user = new Model.AppUser
            {
                Name = registrationDTO.Name,
                UserName = registrationDTO.UserName,
                Email = registrationDTO.Email,
                PhoneNumber = registrationDTO.PhoneNumber,
                BranchId = registrationDTO.BranchId,
                Address = registrationDTO.Address,
                
                
            };

            var result = await userManager.CreateAsync(user, registrationDTO.Password);
            if (!result.Succeeded)
            {
                return 0;
            }

            await reprosatry.CreateAsync( new Model.Marchant
            {
                AppUserId = user.Id,
                StoreName = registrationDTO.StoreName,
                ReturnerPercent = registrationDTO.ReturnerPercent,
                CityId = registrationDTO.CityId,
                GovernorateId = registrationDTO.GovernorateId,
                SpecialPrices = registrationDTO.SpecialPrices.Select(p => new SpecialPrice
                {
                    Price = p.Price,
                    CityId = p.CityId,
                    GovernorateId = p.GovernorateId
                }).ToList()
            });

            await reprosatry.SaveChangesAsync();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role,  "Merchant")

            };
            await userManager.AddClaimsAsync(user, claims);
            return 1;
        }

        public async Task<int> UpdateMerchant(MerchantUpdateDto updateDto)
        {
            var user = await userManager.Users.Include(x => x.Marchant).ThenInclude(x => x.SpecialPrices).FirstOrDefaultAsync(x => x.Id == updateDto.Id);

            if (user == null)
            {
                return 0;
            }

            user.Name = updateDto.Name;
            user.PhoneNumber = updateDto.PhoneNumber;
            user.BranchId = updateDto.BranchId;
            user.Address = updateDto.Address;
            user.Marchant.StoreName = updateDto.StoreName;
            user.Marchant.ReturnerPercent = updateDto.ReturnerPercent;
            user.Marchant.CityId = updateDto.CityId;
            user.Marchant.GovernorateId = updateDto.GovernorateId;

            var specialPrices = updateDto.SpecialPrices.Select(p => new SpecialPrice
            {
                Price = p.Price,
                CityId = p.CityId,
                GovernorateId = p.GovernorateId,
                MerchentId = user.Marchant.MarchantId
            }).ToList();

            List<SpecialPrice> existingSpecialPrices = await specialPricesRepository.GetSpecialPricesByMerchantId(user.Marchant.MarchantId);
            await specialPricesRepository.RemoveRangeAsync(existingSpecialPrices);
            await specialPricesRepository.AddRangeAsync(specialPrices);
            await reprosatry.UpdateMerchant(user.Marchant);
            await userManager.UpdateAsync(user);

            await reprosatry.SaveChangesAsync();
            return 1;
        }

        public async Task<int> UpdateMerchantPassword(UpdatePasswordDtos updatePassDto)
        {
            var merchant = await reprosatry.GetMerchant(e => e.AppUser.Id == updatePassDto.Id && !e.AppUser.IsDeleted) ??
                throw new ExceptionLogic("");
            if (merchant == null)
            {
                return 0;
            }
            merchant.AppUser.Email = updatePassDto.Email;
            merchant.AppUser.PasswordHash = userManager.PasswordHasher.HashPassword(merchant.AppUser, updatePassDto.Password);

            var result = await userManager.UpdateAsync(merchant.AppUser);
            if (!result.Succeeded)
                throw new ExceptionLogic("");

            return merchant.MarchantId;
        }
        public async Task<List<GetAllMerchantsDto>> GetAllMarchentsAsync()
        {
            IReadOnlyList<Model.Marchant> merchants = (await reprosatry.GetAllMerchants()).ToList();
            var data = merchants.Select(m => new GetAllMerchantsDto
            {
                Id = m.AppUser.Id,
                Name = m.AppUser.Name,
                Email = m.AppUser.Email,
                Phone = m.AppUser.PhoneNumber,
                ReturnerPercent = m.ReturnerPercent,
                StoreName = m.StoreName,
                GovernateName = m.Governorate.Name,
                IsDeleted = m.AppUser.IsDeleted,
                BranchName = m.AppUser.branch.Name,
            }).ToList();

            return data;
        }
    }
}
