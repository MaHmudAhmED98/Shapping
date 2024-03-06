using static Shapping.DTO.Weight.Weight;

namespace Shapping.Handler.Weight
{
    public interface IWeightHandler
    {
        Task<int> Add(AddWeightDto order);
        Task<int> Update(UpdateWeightDto order);
        Task<Model.Weight> GetWeightByIdAsync(int id);
    }
}
