using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponCore.Entites
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Price is required.")]
        public double Price { get; set; }

        public IEnumerable<Offer> Offers { get; set; }
    }
}
