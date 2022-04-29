using CouponCore.Dtos;
using CouponCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpPost("/generate")]
        [ProducesResponseType(201, Type = typeof(GetCouponDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GenerateCoupon([FromQuery] int offerId, int numberOfCoupons)
        {
            //To do
            //Check offer Id

            var response = _couponService.GenerateCoupon(offerId, numberOfCoupons);
            return Ok(response);

        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(GetProductDto))]
        public async Task<IActionResult> Get([FromQuery] CouponSearchDto req)
        {
            var response = await _couponService.GetAll(req);
            return Ok(response);
        }
    }
}
