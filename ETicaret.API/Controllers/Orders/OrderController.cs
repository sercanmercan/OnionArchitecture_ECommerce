using AutoMapper;
using ETicaretAPI.Application.Abstractions.AppServices.MailServices;
using ETicaretAPI.Application.Dtos.OrderProducts.Request;
using ETicaretAPI.Application.Dtos.OrderProducts.Response;
using ETicaretAPI.Application.Dtos.Orders.Request;
using ETicaretAPI.Application.Dtos.Orders.Response;
using ETicaretAPI.Application.Repositories.Customers;
using ETicaretAPI.Application.Repositories.Orders;
using ETicaretAPI.Application.Repositories.Products;
using ETicaretAPI.Domain.Entities.Customers;
using ETicaretAPI.Domain.Entities.OrderProducts;
using ETicaretAPI.Domain.Entities.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ETicaretAPI.API.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IMailService _mailService;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly IProductReadRepository _productReadRepository;
        public OrderController(IMapper mapper,
            IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            IMailService mailService,
            ICustomerReadRepository customerReadRepository,
            IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _mailService = mailService;
            _customerReadRepository = customerReadRepository;
            _productReadRepository = productReadRepository;
        }

        /// <summary>
        /// Sipariş oluşturur ve mail gönderir.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUpdateOrderRequestDto request)
        {
            string resultErrorMessage = string.Empty;

            try
            {
                if (!request.IsCheckValid())
                {
                    resultErrorMessage = "Lütfen zorunlu alanları doldurunuz.";
                    throw new ArgumentException(resultErrorMessage);
                }

                var mapping = (_mapper.Map<List<OrderProductRequestDto>, List<OrderProduct>>(request.OrderProducts)).AsQueryable().Include(c => c.Product).ToList(); 

                await _orderWriteRepository.AddAsync(new()
                {
                    FullAddress = request.FullAddress,
                    Description = request.Description,
                    CustomerId = request.CustomerId,
                    OrderProducts = mapping
                });

                var result = await _orderWriteRepository.SaveAsync();

                if(result > 0 )
                {
                    Customer customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);

                    if (customer == null)
                    {
                        resultErrorMessage = "Böyle bir müşteri yoktur";
                        throw new ArgumentException(resultErrorMessage);
                    }
                    double totalPrice = 0;

                    StringBuilder body = new();
                    body.AppendLine($"Sayın {customer.Name},");
                    body.AppendLine("<br/>");
                    body.AppendLine("Siparişiniz oluşturuldu. Sipariş detayları aşağıdaki gibidir:");
                    body.AppendLine("<br/>");

                    foreach (var item in mapping) 
                    {
                        var product = await _productReadRepository.GetByIdAsync(item.ProductId);
                        body.AppendLine($"Ürün adı : {product.Name}");
                        body.AppendLine("<br/>");
                        body.AppendLine($"Ürün adeti : {item.Quantity}");
                        body.AppendLine("<br/>");
                        body.AppendLine($"Ürün birim fiyatı : {product.Price}₺");
                        body.AppendLine("------------------------------------------");
                        body.AppendLine("<br/>");
                        body.AppendLine("<br/>");
                        totalPrice = (item.Quantity * product.Price) + totalPrice;
                    }

                    body.AppendLine($"Toplam tutar: {totalPrice}₺");
                    await _mailService.SendMessageAsync(customer.Email, "Sipariş Faturası", body.ToString());
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : "Bir hata olustu");
            }
        }

        [HttpGet]
        public List<OrderResponseDto> GetAllOrder()
        {
            List<Order> orderList = _orderReadRepository.GetAll(false).ToList();
            List<OrderResponseDto> map = _mapper.Map<List<Order>, List<OrderResponseDto>>(orderList);
            return map;
        }
    }
}
