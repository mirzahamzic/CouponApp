using CouponCore.Dtos;
using CouponCore.Dtos.Coupon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CouponCore.Interfaces
{
    public interface ICouponService
    {
        Task<IEnumerable<GetCouponDto>> GetAll(CouponSearchDto req);

        Task<IEnumerable<GeneratedCouponsDto>> GenerateCoupon(int offerId, int numberOfCoupons);

        Task<string> RemoveCoupon(int couponId);
    }
}