using AutoMapper;
using CouponCore.Dtos;
using CouponCore.Entites;

namespace CouponAPI
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Coupon, GetCouponDto>()
                .ForMember(dest => dest.ProductName, o => o.MapFrom(src => src.Offer.Product.Name))
                .ReverseMap();
            CreateMap<GetProductDto, AddProductDto>().ReverseMap();
        }
    }
}