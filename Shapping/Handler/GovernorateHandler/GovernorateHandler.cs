using Shapping.DTO.Governoret;
using Shapping.Model;
using Shapping.Reprostary.Governorate;

namespace Shapping.Handler.GovernorateHandler
{
    public class GovernorateHandler:IGovernorateHandler
    {
        private readonly IGovernorateRepository governorateRepository;

        public GovernorateHandler(IGovernorateRepository governorateRepository)
        {
            this.governorateRepository = governorateRepository;
        }

        public List<ShowGovernorateDTO> GetAllWithDelet()
        {    var govers = governorateRepository.GetAllWithDelete();
            if(govers == null) { throw new ExceptionLogic(""); }
            return govers;
        }

        public List<ShowGovernorateWithCityDropdownDTO> GetAllWithCityDropdown()
        {
            var govers = governorateRepository.GetAll();
            if (govers == null) { throw new ExceptionLogic(""); }
            return govers;
        }

        public void AddGovern(AddGovernorateDTO governorateDTO)
        {
            if(governorateDTO == null) { throw new ExceptionLogic(""); }
            governorateRepository.AddGover(governorateDTO);
            governorateRepository.SaveChanges();
        }

        public void Update(UpdateGovernorateDTO upDto)
        {
            if(upDto == null) { throw new ExceptionLogic(""); }
            governorateRepository.Update(upDto);
            governorateRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            if(id == 0) { throw new ExceptionLogic(""); }
            governorateRepository.Delete(id);
            governorateRepository.SaveChanges();
        }


        public ReadGovernorateDTO GetById(int id)
        {
          return  governorateRepository.GetGovernorateWithCities(id);
        }


    }
}
