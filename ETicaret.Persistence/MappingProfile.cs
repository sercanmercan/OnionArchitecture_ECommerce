using AutoMapper;
using ETicaretAPI.Application.Dtos.OrderProducts.Request;
using ETicaretAPI.Application.Dtos.OrderProducts.Response;
using ETicaretAPI.Application.Dtos.Products.Request;
using ETicaretAPI.Application.Dtos.Products.Response;
using ETicaretAPI.Domain.Entities.OrderProducts;
using ETicaretAPI.Domain.Entities.Products;

namespace ETicaretAPI.Persistence
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateUpdateProductRequestDto, Product>();
            CreateMap<ProductResponseDto, Product>();
            CreateMap<Product, ProductResponseDto>();

            CreateMap<OrderProductRequestDto, OrderProduct>();
            //CreateMap<OrderProduct, OrderProductResponseDto>()
            //    .ForMember(c => c.Product, x => x.MapFrom(y => y.Product));
            //CreateMap<OrderProductResponseDto, OrderProduct>();
        }
    }
}
