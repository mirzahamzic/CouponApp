using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CouponCore.Entites
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Price is required.")]
        public double Price { get; set; }

        public IEnumerable<Offer> Offers { get; set; }
    }
}