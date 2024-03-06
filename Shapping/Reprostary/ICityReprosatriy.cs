using Shapping.DTO.City;
using Shapping.DTO.Governoret;
using Shapping.Model;

namespace Shapping.Reprostary
{
    public interface ICityReprosatriy
    {
        public List<ShowCityDTO> GetAll();
        public List<ShowCityDropDwon> GettallShowDrop();
        public City GetById(int Id);
        public void AddCity(AddCityDto addCity);
        public void DeletCity(int id);
        public void UpdateCity(UpdateCityDto updateCity);
        public void SaveChanges();

    }
}
