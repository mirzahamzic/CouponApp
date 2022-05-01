using CouponCore.Dtos;
using CouponCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly IOfferService _offerservice;

        public CouponsController(ICouponService couponService, IOfferService offerservice)
        {
            _couponService = couponService;
            _offerservice = offerservice;
        }

        [HttpPost("/generate")]
        [ProducesResponseType(201, Type = typeof(GetCouponDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GenerateCoupon([FromQuery] int offerId, int numberOfCoupons)
        {
            if (!_offerservice.OfferExists(offerId))
                return NotFound();

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _couponService.RemoveCoupon(id);

            return Ok(response);
        }
    }
}