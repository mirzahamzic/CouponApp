using CouponCore.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponData
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
