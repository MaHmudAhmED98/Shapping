﻿namespace Shapping.DTO.City
{
    public class UpdateCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double? Pickup { get; set; }

        public int GovernorateId { get; set; }
    }
}
