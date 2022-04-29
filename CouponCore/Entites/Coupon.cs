using System;
using System.ComponentModel.DataAnnotations;

namespace CouponCore.Entites
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Serial number is required")]
        public Guid SerialNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}