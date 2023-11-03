using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.Mail.Request
{
    public class MailServiceRequestDto
    {
        public string[] Tos { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
