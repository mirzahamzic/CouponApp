using System;

namespace CouponCore.Dtos
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}