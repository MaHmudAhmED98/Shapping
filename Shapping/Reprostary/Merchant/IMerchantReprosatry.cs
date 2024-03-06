using Shapping.Model;
using System.Linq.Expressions;

namespace Shapping.Reprostary.Merchant
{
    public interface IMerchantReprosatry
    {
        public Task<Marchant?> GetMerchant(Expression<Func<Marchant, bool>> predicate);
        public Task UpdateMerchant(Marchant merchant);
        public Task<IEnumerable<Marchant>> GetAllMerchants();

        Task CreateAsync(Marchant merchant);
        Task<int> SaveChangesAsync();
    }
}
