using CouponData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CouponAPI.Extensions
{
    public static class DBConnectionExtension
    {
        public static void AddDBConnection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
        }
    }
}
