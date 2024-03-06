using System.ComponentModel.DataAnnotations.Schema;

namespace Shapping.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Weigth { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool isDeleted { get; set; } = false;

        [ForeignKey("order")]
        public int? OrderId { get; set; }
        public virtual Order? order { get; set; }
    }
}
