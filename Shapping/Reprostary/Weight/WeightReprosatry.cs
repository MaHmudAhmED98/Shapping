
using Microsoft.EntityFrameworkCore;
using Shapping.Model;

namespace Shapping.Reprostary.Weight
{
    public class WeightReprosatry : IWeightReperosatry
    {
        private readonly ShapingContext context;

        public WeightReprosatry(ShapingContext context) 
        {
            this.context = context;
        }
        public async Task<int> Add(DTO.Weight.Weight.AddWeightDto orderDto)
        {
            var weight = new Model.Weight
            {
                DefaultWeight = orderDto.DefaultWeight,
                AdditionalPrice = orderDto.AdditionalPrice
            };

            context.Weights.Add(weight);
            await context.SaveChangesAsync();

            return weight.Id;
        }

        public Task<List<Model.Weight>> GetWeight()
        {
            return context.Weights.ToListAsync();
        }

        public async Task<Model.Weight> GetWeightByIdAsync(int id)
        {
            return await context.Weights.FirstOrDefaultAsync(c=> c.Id == id);
        }


        public async Task<int> Update(DTO.Weight.Weight.UpdateWeightDto orderDto)
        {
            var weight = await context.Weights.FirstOrDefaultAsync(c => c.Id == orderDto.Id);
            if (weight == null)
            {
                throw new Exception("Weight not found");
            }
            //context.Weights.Update(weight);
            weight.DefaultWeight = orderDto.DefaultWeight;
            weight.AdditionalPrice = orderDto.AdditionalPrice;
            await context.SaveChangesAsync();
            return weight.Id;
        }

    }
}
