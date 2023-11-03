using ETicaretAPI.Application.Dtos.OrderProducts.Request;
using ETicaretAPI.Application.Dtos.Products.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.OrderProducts.Response
{
    public class OrderProductResponseDto : OrderProductRequestDto
    {
        public ProductResponseDto Product { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
