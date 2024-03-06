using Shapping.DTO.Governoret;

namespace Shapping.Reprostary.Governorate
{
    public interface IGovernorateRepository
    {
        public List<ShowGovernorateDTO> GetAllWithDelete();
        public List<ShowGovernorateWithCityDropdownDTO> GetAll();
        public Model.Governorate GetById(int id);
        public void AddGover(AddGovernorateDTO addDto);
        public void Update(UpdateGovernorateDTO updatDto);
        public void Delete(int id);
        public void SaveChanges();
        public ReadGovernorateDTO GetGovernorateWithCities(int governorateId);
    }
}
