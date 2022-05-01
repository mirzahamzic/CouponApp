using AutoMapper;
using CouponCore.Dtos;
using CouponCore.Dtos.Coupon;
using CouponCore.Entites;
using System;
using System.Linq;

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
            CreateMap<GetOfferDto, Offer>().ReverseMap()
                .ForMember(dest => dest.IsActive, o => o.MapFrom(src => src.EndAt > DateTime.Today))
                .ForMember(dest => dest.CouponsLeft, o => o.MapFrom(src => src.Coupons.Count()));
            CreateMap<GeneratedCouponsDto, Coupon>().ReverseMap();
        }
    }
}