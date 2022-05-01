namespace CouponCore.Dtos.Offer
{
    public class OfferSearchDto : BaseSearchDto
    {
        public string ProductName { get; set; }
        public bool? IsActive { get; set; }
    }
}