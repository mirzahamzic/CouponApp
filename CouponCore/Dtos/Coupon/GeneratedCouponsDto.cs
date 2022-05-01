using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponCore.Dtos.Coupon
{
    public class GeneratedCouponsDto
    {
        public int Id { get; set; }
        public Guid SerialNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        //public int OfferId { get; set; }
        //public string OfferName { get; set; }
        //public string ProductName { get; set; }
    }
}
