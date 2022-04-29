using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CouponAPI.Extensions
{
    public static class SwaggerConfigurationExtension
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JapTask1.Api", Version = "v1" });
            });
        }
    }
}