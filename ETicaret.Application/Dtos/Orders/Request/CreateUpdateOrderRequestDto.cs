using ETicaretAPI.Application.Dtos.OrderProducts.Request;
using ETicaretAPI.Domain.Entities.Customers;
using ETicaretAPI.Domain.Entities.OrderProducts;
using ETicaretAPI.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.Orders.Request
{
    public class CreateUpdateOrderRequestDto
    {
        public string? Description { get; set; }
        public string FullAddress { get; set; }
        public Guid CustomerId { get; set; }
        public List<OrderProductRequestDto> OrderProducts { get; set; }

        public bool IsCheckValid()
        {
            if (string.IsNullOrWhiteSpace(FullAddress) || CustomerId == Guid.Empty || OrderProducts is null)
                return false;
            return true;
        }
    }
}
