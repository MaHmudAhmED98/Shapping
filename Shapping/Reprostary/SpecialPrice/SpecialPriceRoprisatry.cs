
using Microsoft.EntityFrameworkCore;
using Shapping.Model;

namespace Shapping.Reprostary.SpecialPrice
{
    public class SpecialPriceRoprisatry : ISpecialPriceRopresatry
    {
        private readonly ShapingContext context;

        public SpecialPriceRoprisatry(ShapingContext context)
        {
            this.context = context;
        }
        public async Task<int> AddRangeAsync(List<Model.SpecialPrice> specialPrices)
        {
            if (specialPrices == null || specialPrices.Count == 0)
            {
                return 0;
            }

            await context.SpecialPrices.AddRangeAsync(specialPrices);
            return await context.SaveChangesAsync();
        }

        public Task<List<Model.SpecialPrice>> GetAllAsync()
        {
            return context.SpecialPrices.ToListAsync();
        }

        public async Task<List<Model.SpecialPrice>> GetSpecialPricesByMerchantId(int Id)
        {
            return  context.SpecialPrices.Where(s => s.MerchentId == Id).ToList();
        }

        public async Task<int> RemoveRangeAsync(List<Model.SpecialPrice> specialPrices)
        {
            if (specialPrices == null || specialPrices.Count == 0)
            {
                return 0;
            }

            context.SpecialPrices.RemoveRange(specialPrices);
            return await context.SaveChangesAsync();
        }
    }
}
