using System;

namespace CouponCore.Dtos
{
    public class AddOfferDto
    {
        public string Name { get; set; }
        public double Saving { get; set; }
        public DateTime StartAt { get; set; } = DateTime.Today;
        public DateTime EndAt { get; set; }
        public bool IsActive { get; set; } = true;
        public int ProductId { get; set; }
    }
}