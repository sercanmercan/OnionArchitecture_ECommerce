using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.OrderProducts.Request
{
    public class OrderProductRequestDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
