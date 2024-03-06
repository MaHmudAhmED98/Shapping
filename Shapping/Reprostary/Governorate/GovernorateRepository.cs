﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shapping.DTO.City;
using Shapping.DTO.Governoret;
using Shapping.Model;

namespace Shapping.Reprostary.Governorate
{
    public class GovernorateRepository:IGovernorateRepository
    {
        private readonly ShapingContext context;

        public GovernorateRepository(ShapingContext Context)
        {
            context = Context;
        }

        public List<ShowGovernorateDTO> GetAllWithDelete()
        {
            var Govers=  context.Governorates.ToList();
            List<ShowGovernorateDTO> GovShowList = new List<ShowGovernorateDTO>();
            foreach (var Gover in Govers)
            {
                GovShowList.Add(new ShowGovernorateDTO
                {
                    Id = Gover.Id,
                    Name = Gover.Name,
                    IsDeleted = Gover.IsDeleted
                });
            }
            return GovShowList;
        }
        public List<ShowGovernorateWithCityDropdownDTO> GetAll()
        {
            var govers  = context.Governorates.Include(g => g.Cities).Where(g=>g.IsDeleted==false).ToList();


            List<ShowGovernorateWithCityDropdownDTO> GovShowList = new List<ShowGovernorateWithCityDropdownDTO>();

            foreach (var Gover in govers)
            {
                GovShowList.Add(new ShowGovernorateWithCityDropdownDTO
                {
                    Id = Gover.Id,
                    Name = Gover.Name,
                    Cities = Gover.Cities.Where(c=>c.isDeleted==false).Select(c=>new ShowCityDropDwon { Id=c.Id,Name=c.Name}).ToList(),
                });
            }

            return GovShowList;
        }

        public Model.Governorate GetById (int id)
        {
            return context.Governorates.Include(g => g.Cities).FirstOrDefault(g => g.Id == id);
        }

        public void AddGover(AddGovernorateDTO addDto)
        {
            context.Add(new Model.Governorate
            {
                Name = addDto.Name,
                
            });
        }
        public void Update(UpdateGovernorateDTO updatDto)
        {
            var GoverUpdate  = GetById(updatDto.Id);
            if(GoverUpdate == null) { throw new ExceptionLogic(""); }
            GoverUpdate.Name = updatDto.Name;

            context.Update(GoverUpdate);

        }

        public void Delete(int id)
        {
            var gover = GetById(id);
            if(gover == null) { throw new ExceptionLogic(""); }
            gover.IsDeleted = true;
            context.Update(gover);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public ReadGovernorateDTO GetGovernorateWithCities(int governorateId)
        {
            var governorate = context.Governorates.Include(g => g.Cities).FirstOrDefault(g => g.Id == governorateId);

            if (governorate == null)
            {
                return null;
            }

            var dto = new ReadGovernorateDTO
            {
                Id = governorate.Id,
                Name = governorate.Name,
                Cities = governorate.Cities.Select(c => new ReadCityDTO
                {
                    id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Pickup = c.Pickup,
                }).ToList()
            };
            return dto;
        }


    }
}
