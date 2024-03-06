using Shapping.DTO.City;
using Shapping.DTO.Governoret;

namespace Shapping.Handler.City
{
    public interface ICityHandler
    {
        public List<ShowCityDTO> Gettall();
        public List<ShowCityDropDwon> GetCityDropDwons();
        public void AddCity(AddCityDto cityDto);
        public void Update(UpdateCityDto cityDto);
        public void DeletCity(int cityId);
        public UpdateCityDto GetById(int id);
    }
}
