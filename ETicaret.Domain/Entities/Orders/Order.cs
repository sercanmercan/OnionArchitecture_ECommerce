using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Customers;
using ETicaretAPI.Domain.Entities.OrderProducts;
using ETicaretAPI.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretAPI.Domain.Entities.Orders
{
    public class Order : BaseEntity<Guid>
    {
        public string? Description { get; set; }
        public string FullAddress { get; set; }
        //public ICollection<Product> Products { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
