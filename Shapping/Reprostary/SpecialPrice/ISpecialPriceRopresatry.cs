﻿using Shapping.Model;

namespace Shapping.Reprostary.SpecialPrice
{
    public interface ISpecialPriceRopresatry
    {
        Task<List<Model.SpecialPrice>> GetSpecialPricesByMerchantId(int Id);
        Task<int> AddRangeAsync(List<Model.SpecialPrice> specialPrices);
        Task<int> RemoveRangeAsync(List<Model.SpecialPrice> specialPrices);
        Task<List<Model.SpecialPrice>> GetAllAsync();
    }
}
