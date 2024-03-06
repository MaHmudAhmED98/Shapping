using Shapping.DTO.Governoret;
using Shapping.Model;

namespace Shapping.Handler.GovernorateHandler
{
    public interface IGovernorateHandler
    {
        public List<ShowGovernorateDTO> GetAllWithDelet();
        public List<ShowGovernorateWithCityDropdownDTO> GetAllWithCityDropdown();
        public void AddGovern(AddGovernorateDTO governorateDTO);
        public void Update(UpdateGovernorateDTO upDto);
        public void Delete(int id);
        public ReadGovernorateDTO GetById(int id);
    }
}
