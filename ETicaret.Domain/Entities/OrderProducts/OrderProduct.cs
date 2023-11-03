using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Orders;
using ETicaretAPI.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretAPI.Domain.Entities.OrderProducts
{
    public class OrderProduct : BaseEntity<Guid>
    {
        [ForeignKey("OrdersId")]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("ProductsId")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
