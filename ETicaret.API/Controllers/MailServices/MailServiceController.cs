using ETicaretAPI.Application.Abstractions.AppServices.MailServices;
using ETicaretAPI.Application.Dtos.Mail.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers.MailServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailServiceController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailServiceController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMailAsync(MailServiceRequestDto request)
        {
           await _mailService.SendMessageAsync(request.Tos, request.Subject, request.Body);
            return Ok();
        }
    }
}
