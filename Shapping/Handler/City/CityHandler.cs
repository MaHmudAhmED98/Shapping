using Shapping.DTO.City;
using Shapping.DTO.Governoret;
using Shapping.Model;
using Shapping.Reprostary;
using Shapping.Reprostary.Governorate;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shapping.Handler.City
{
    public class CityHandler : ICityHandler
    {
        private readonly ICityReprosatriy reprosatriy;
        private readonly IGovernorateRepository governorateRepository;

        public CityHandler(ICityReprosatriy reprosatriy ,IGovernorateRepository governorateRepository)
        {
            this.reprosatriy = reprosatriy;
            this.governorateRepository = governorateRepository;
        }
        public List<ShowCityDTO> Gettall()
        {
            return reprosatriy.GetAll();
        }
        public UpdateCityDto GetById(int id)
        {
            var city = reprosatriy.GetById(id);
            if (city == null)
            {
                return null;
            }
            return new UpdateCityDto
            {
                Id = city.Id,
                Name = city.Name,
                Pickup = city.Pickup,
                Price = city.Price,
                GovernorateId = city.GovernorateId
            };
        }
        public List<ShowCityDropDwon> GetCityDropDwons()
        {
            return reprosatriy.GettallShowDrop();
        }
        public void AddCity(AddCityDto cityDto)
        {
            var governorate = governorateRepository.GetById(cityDto.GovernorateId);

            if (governorate == null)
            {
                throw new Exception("Governorate not found");
            }
            reprosatriy.AddCity(cityDto);
            reprosatriy.SaveChanges();
        }
        public void Update(UpdateCityDto cityDto)
        {
            reprosatriy.UpdateCity(cityDto);
            reprosatriy.SaveChanges();
        }
        public void DeletCity(int  cityId)
        {
            reprosatriy.DeletCity(cityId);
            reprosatriy.SaveChanges();
        }

    }
}
