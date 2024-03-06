using System.ComponentModel.DataAnnotations.Schema;

namespace Shapping.Model
{
    public class City
    {

        public int Id { get; set; }
        public string Name { get; set; } 
        public double Price { get; set; }
        public double? Pickup { get; set; }
        public bool isDeleted { get; set; } = false;

        [ForeignKey("Governorate")]
        public int GovernorateId { get; set; }
        public virtual Governorate? Governorate { get; set; }
        public virtual ICollection<SpecialPrice> SpecialPrices { get; set; } = new HashSet<SpecialPrice>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
