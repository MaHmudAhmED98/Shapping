using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shapping.Model;
using System.Linq.Expressions;

namespace Shapping.Reprostary.Merchant
{
    public class MerchantReprosatry : IMerchantReprosatry
    {
        private readonly UserManager<AppUser> user;
        private readonly ShapingContext context;

        public MerchantReprosatry(UserManager<AppUser> user, ShapingContext context)
        {
            this.user = user;
            this.context = context;
        }

        public async Task CreateAsync(Marchant merchant)
        {
            await context.Marchants.AddAsync(merchant);
        }

        public async Task<IEnumerable<Marchant>> GetAllMerchants()
        {
            return await context.Marchants
                .Include(x => x.AppUser)
                .ThenInclude(x => x.branch)
                .Include(x => x.City)
                .Include(x => x.Governorate).ToListAsync();
        }

        public async Task<Marchant?> GetMerchant(Expression<Func<Marchant, bool>> predicate)
        {
            return context.Marchants.Include(x => x.SpecialPrices).Include(x => x.AppUser).FirstOrDefault(predicate);
        }

        public async Task<int> SaveChangesAsync()
            => await context.SaveChangesAsync();

        public async Task UpdateMerchant(Marchant merchant)
        {
            context.Marchants.Update(merchant);
            
        }
    }
}
