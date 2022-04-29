using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CouponCore.Entites
{
    public class Offer : BaseEntity
    {
        [Required(ErrorMessage = "Savings amount is required.")]
        public double Saving { get; set; }

        public DateTime StartAt { get; set; } = DateTime.Today;
        public DateTime EndAt { get; set; }
        public bool IsActive { get; set; } = true;

        public IEnumerable<Coupon> Coupons { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}