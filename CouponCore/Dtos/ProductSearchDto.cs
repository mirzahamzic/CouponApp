using CouponCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponCore.Dtos
{
    public class ProductSearchDto : BaseSearchDto
    {
        public string Name { get; set; }

    }
}
