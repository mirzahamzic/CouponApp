using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponCore.Dtos
{
    public class CouponSearchDto : BaseSearchDto
    {
        public string SerialNumber { get; set; }
    }
}
