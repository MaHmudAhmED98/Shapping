using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Shapping.DTO.City;
using Shapping.DTO.Governoret;
using Shapping.Model;

namespace Shapping.Reprostary
{
    public class CityReprosatriy :ICityReprosatriy
    {
        private readonly ShapingContext context;

        public CityReprosatriy(ShapingContext context)
        {
            this.context = context;
        }
        public List<ShowCityDTO> GetAll()
        {
            var cities= context.Cities.ToList();
            List<ShowCityDTO> showCityDTOs = new List<ShowCityDTO>();
            var governorates = context.Governorates.Include(g => g.Cities).ToList();
            foreach (var city in cities)
            {
                showCityDTOs.Add(new ShowCityDTO
                {
                    id=city.Id,
                    Name=city.Name,
                    Pickup = city.Pickup,
                    Price=city.Price,
                    GovernorateId=city.GovernorateId,

                });
            }
            return showCityDTOs;
        }
        public List<ShowCityDropDwon> GettallShowDrop()
        {
            var cities = context.Cities.ToList();
            List<ShowCityDropDwon> dropDwons = new List<ShowCityDropDwon>();
            var governorates = context.Governorates.Include(g => g.Cities).ToList();
            foreach (var city in cities)
            {
                dropDwons.Add(new ShowCityDropDwon { Id=city.Id, Name=city.Name });
            }
            return dropDwons;
        }
        public City GetById(int Id)
        {
            return context.Cities.FirstOrDefault(c=>c.Id==Id);    
        }
        public void UpdateCity (UpdateCityDto updateCity)
        {
            var city = GetById(updateCity.Id);
            if(city == null)
            {
                throw new ExceptionLogic("Empty");
            }
            city.Name = updateCity.Name;
            city.Price = updateCity.Price;
            city.Pickup = updateCity.Pickup;
            city.Governorate.Id = updateCity.GovernorateId;
            context.Update(city);
        }
        public void AddCity(AddCityDto addCity)
        {

            context.Add(new City
            {
                Name = addCity.Name,
                Price = addCity.Price,
                GovernorateId = addCity.GovernorateId,
                Pickup = addCity.Pickup,
            });
        }
        public void DeletCity(int id)
        {
            var CityId = GetById(id);
            if (CityId == null)
            {
                throw new ExceptionLogic("Empty");
            }
            context.Remove(CityId);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }


       
    }
}
