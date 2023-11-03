using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.OrderProducts;
using ETicaretAPI.Domain.Entities.Orders;

namespace ETicaretAPI.Domain.Entities.Products
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        //public ICollection<Order> Orders { get; set; }

    }
}
