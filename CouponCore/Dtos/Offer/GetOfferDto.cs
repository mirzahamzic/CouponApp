using CouponCore.Entites;
using System;
using System.Collections.Generic;

namespace CouponCore.Dtos
{
    public class GetOfferDto
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Saving { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public bool IsActive { get; set; }
        public List<GetCouponDto> Coupons { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}