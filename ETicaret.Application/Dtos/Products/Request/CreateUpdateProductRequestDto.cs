using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.Products.Request
{
    public class CreateUpdateProductRequestDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public bool IsCheckValid()
        {
            if (string.IsNullOrWhiteSpace(Name) || Price <= 0 || Stock <= 0)
                return false;
            return true;
        }
    }
}
