using ETicaretAPI.Application.Dtos.Customers.Request;
using ETicaretAPI.Application.Dtos.Products.Request;
using ETicaretAPI.Application.Repositories.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;

        public CustomerController(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUpdateCustomerRequestDto request)
        {
            string resultErrorMessage = string.Empty;
            try
            {
                if (!request.IsCheckValid())
                {
                    resultErrorMessage = "Lütfen zorunlu alanları doldurunuz.";
                    throw new ArgumentException(resultErrorMessage);
                }

                await _customerWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email
                });

                await _customerWriteRepository.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : "Bir hata olustu");
            }
        }
    }
}
