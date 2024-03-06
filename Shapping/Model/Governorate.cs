﻿namespace Shapping.Model
{
    public class Governorate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public virtual ICollection<SpecialPrice> SpecialPrices { get; set; } = new HashSet<SpecialPrice>();
    }
}
