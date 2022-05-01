using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponCore.Dtos.Offer
{
    public class OfferSearchDto : BaseSearchDto
    {
        public string ProductName { get; set; }
        public bool? IsActive { get; set; }
    }
}
