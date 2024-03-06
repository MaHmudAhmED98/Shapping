using Shapping.DTO.Weight;
using Shapping.Model;
using static Shapping.DTO.Weight.Weight;

namespace Shapping.Reprostary.Weight
{
    public interface IWeightReperosatry
    {
        Task<int> Add(AddWeightDto order);
        Task<int> Update(UpdateWeightDto order);
        Task<Model.Weight> GetWeightByIdAsync(int id);
        Task<List<Model.Weight>> GetWeight();
    }
}
