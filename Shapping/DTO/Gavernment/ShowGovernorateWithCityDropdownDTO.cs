﻿using Shapping.DTO.City;

namespace Shapping.DTO.Governoret
{
    public class ShowGovernorateWithCityDropdownDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ShowCityDropDwon> Cities { get; set; }
    }
}
