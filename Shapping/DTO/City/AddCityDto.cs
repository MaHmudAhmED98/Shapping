﻿namespace Shapping.DTO.City
{
    public class AddCityDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double? Pickup { get; set; }
        public int GovernorateId { get; set; }
    }
}
