using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.Customers.Request
{
    public class CreateUpdateCustomerRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool IsCheckValid()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(PhoneNumber))
                return false;
            return true;
        }
    }
}
