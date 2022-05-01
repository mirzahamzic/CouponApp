namespace CouponCore.Dtos
{
    public class CouponSearchDto : BaseSearchDto
    {
        public string SerialNumber { get; set; }
        public string OfferName { get; set; }
        public string ProductName { get; set; }
    }
}