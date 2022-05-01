namespace CouponCore.Dtos
{
    public class BaseSearchDto
    {
        public int? Limit
        {
            get
            {
                return (Page - 1) * PageSize;
            }
        }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}