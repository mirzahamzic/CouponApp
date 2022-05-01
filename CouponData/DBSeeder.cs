using CouponCore.Entites;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CouponData
{
    public class DBSeeder
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<DataContext>();

            if (!context.Products.Any())
            {
                await context.Products.AddRangeAsync(
                     new Product { Name = "Nuttela Palacinci", Price = 5 },
                     new Product { Name = "Palacinci sa sladoledom", Price = 8 },
                     new Product { Name = "Lokumi sa Nutellom", Price = 10 }
                     );
                await context.SaveChangesAsync();
            };

            if (!context.Offers.Any())
            {
                await context.Offers.AddRangeAsync(
                   new Offer { Name = "Ponuda Nutella Palacinci 1+2", Saving = 10, StartAt = DateTime.Today, EndAt = DateTime.Now.AddDays(4), ProductId = 1 },
                   new Offer { Name = "Ponuda Palacinci sa sladolodom 1+1", Saving = 5, StartAt = DateTime.Now.AddDays(1), EndAt = DateTime.Now.AddDays(5), ProductId = 2 },
                   new Offer { Name = "Lokumi sa Nutellom 1+4", Saving = 40, StartAt = DateTime.Today, EndAt = DateTime.Now.AddDays(20), ProductId = 3 },
                   new Offer { Name = "Nutella Palacinci 1+4", Saving = 40, StartAt = DateTime.Now.AddDays(-10), EndAt = DateTime.Now.AddDays(-5), ProductId = 1 }
                    );
                await context.SaveChangesAsync();
            }
        }
    }
}