using ETicaretAPI.Application.Dtos.Products.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.Products.Response
{
    public class ProductResponseDto : CreateUpdateProductRequestDto
    {
        public Guid Id { get; set; }

    }
}
