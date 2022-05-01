using System;

namespace CouponCore.Dtos
{
    public class GetCouponDto
    {
        public int Id { get; set; }
        public Guid SerialNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public string ProductName { get; set; }
    }
}