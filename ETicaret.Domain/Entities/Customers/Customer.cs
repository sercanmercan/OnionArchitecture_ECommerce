using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Orders;

namespace ETicaretAPI.Domain.Entities.Customers
{
    public class Customer : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
