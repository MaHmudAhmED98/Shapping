using System.ComponentModel.DataAnnotations.Schema;

namespace Shapping.Model
{
    public enum AmountType
    {
        Percent,
        Fixed
    }
    public class Representative 
    {
        public int Id { get; set; }
        public double? Amount { get; set; }
        public AmountType? Type { get; set; }
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
