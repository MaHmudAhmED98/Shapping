using Microsoft.EntityFrameworkCore;
using Shapping.Model;

namespace Shapping.Reprostary.Product
{
    public class ProductReprosatry :IProductRepeosatry
    {
        private readonly ShapingContext context;

        public ProductReprosatry(ShapingContext context)
        {
            this.context = context;
        }

        public bool AddRange(List<Model.Product> products)
        {
            try
            {
                context.Products.AddRange(products);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteRange(List<Model.Product> products)
        {
            try
            {
                context.Products.RemoveRange(products);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Model.Product> GetProductsByOrderId(int id)
        {
            return context.Products.Where(d => d.isDeleted == false && d.OrderId == id).ToList();

        }
    }
}
