using CouponCore.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CouponCore.Helpers
{
    public class GeneralHelperClass
    {
        public static Coupon GetRandomCoupon(IEnumerable<Coupon> coupons)
        {
            var rnd = new Random();
            var min = coupons.Min(c => c.Id);
            var max = coupons.Max(c => c.Id);
            var randomCouponIndex = rnd.Next(min, max + 1);
            var randomCoupon = coupons.FirstOrDefault(c => c.Id == randomCouponIndex);

            return randomCoupon;
        }
    }
}