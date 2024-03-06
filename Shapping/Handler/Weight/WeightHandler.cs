using Shapping.Reprostary.Weight;
using System.ComponentModel.DataAnnotations;

namespace Shapping.Handler.Weight
{
    public class WeightHandler : IWeightHandler
    {
        private readonly IWeightReperosatry reperosatry;

        public WeightHandler(IWeightReperosatry reperosatry)
        {
            this.reperosatry = reperosatry;
        }

        public Task<int> Add(DTO.Weight.Weight.AddWeightDto order)
        {
            Validator.ValidateObject(order, new ValidationContext(order), true);
            return reperosatry.Add(order);
        }

        public Task<Model.Weight> GetWeightByIdAsync(int id)
        {

            return reperosatry.GetWeightByIdAsync(id);
        }

        public Task<int> Update(DTO.Weight.Weight.UpdateWeightDto order)
        {
            Validator.ValidateObject(order, new ValidationContext(order), true);

            return reperosatry.Update(order);
        }
    }
}
