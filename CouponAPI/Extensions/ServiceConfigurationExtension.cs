using CouponCore.Interfaces;
using CouponServices;
using Microsoft.Extensions.DependencyInjection;

namespace CouponAPI.Extensions
{
    public static class ServiceConfigurationExtension
    {
        public static void AddHttpServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICouponService, CouponService>();

        }
    }
}