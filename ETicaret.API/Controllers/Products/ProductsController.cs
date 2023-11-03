using AutoMapper;
using ETicaretAPI.Application.Dtos.Products.Request;
using ETicaretAPI.Application.Dtos.Products.Response;
using ETicaretAPI.Application.Repositories.Products;
using ETicaretAPI.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        public ProductsController(IMapper mapper,
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm ürünleri listeler.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductResponseDto> GetAllProduct()
        {
            List<Product> productList = _productReadRepository.GetAll(false).ToList();
            List<ProductResponseDto> map = _mapper.Map<List<Product>, List<ProductResponseDto>>(productList);
            return map;
        }

        /// <summary>
        /// Id ye göre ürünü getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id, false);
            return Ok(product);
        }

        /// <summary>
        /// Ürünüekleme işlemi yaptırır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUpdateProductRequestDto request)
        {
            string resultErrorMessage = string.Empty;
            try
            {
                if(!request.IsCheckValid())
                {
                    resultErrorMessage = "Lütfen zorunlu alanları doldurunuz.";
                    throw new ArgumentException(resultErrorMessage);
                }

                await _productWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                    Price = request.Price,
                    Stock = request.Stock
                });
                await _productWriteRepository.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : "Bir hata olustu");
            }
        }

        /// <summary>
        /// id ye göre gelen ürünü güncelleme işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpPut]
        public async Task<bool> UpdateAsync(Guid id, CreateUpdateProductRequestDto request)
        {
            string resultErrorMessage = string.Empty;

            try
            {
                if (!request.IsCheckValid())
                {
                    resultErrorMessage = "Lütfen bilgileri giriniz.";
                    throw new ArgumentException(resultErrorMessage);
                }

                Product product = await _productReadRepository.GetByIdAsync(id, true);

                if (product is null)
                {
                    resultErrorMessage = "Böyle bir ürün yok.";
                    throw new ArgumentException(resultErrorMessage);
                }

                product.Name = request.Name;
                product.Price = request.Price;
                product.Stock = request.Stock;
                _productWriteRepository.Update(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : "Bir hata olustu");
            }
        }

        /// <summary>
        /// Id ye göre gelen ürünü isdeleted kolonunu true yaparak soft delete işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteProductAsync(Guid id)
        {
            string resultErrorMessage = string.Empty;

            try
            {
                Product? product = await _productReadRepository.GetByIdAsync(id);

                if (product is null)
                {
                    resultErrorMessage = "Böyle bir ürün yok.";
                    throw new ArgumentException(resultErrorMessage);
                }

                product.IsDeleted = true;
                product.DeletedDate = DateTime.Now;
                _productWriteRepository.Update(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : "Bir hata olustu");
            }
        }
    }
}
