using CouponCore.Dtos;
using CouponCore.Dtos.Offer;
using CouponCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(GetOfferDto))]
        public async Task<IActionResult> Get([FromQuery] OfferSearchDto req)
        {
            var response = await _offerService.GetAll(req);
            return Ok(response);
        }

        [HttpGet("{offerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(GetOfferDto))]
        public async Task<IActionResult> GetById(int offerId)
        {
            if (!_offerService.OfferExists(offerId)) return NotFound();

            var response = await _offerService.GetById(offerId);

            return Ok(response);
        }

        [HttpGet("UseCoupon/{offerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(GetOfferDto))]
        public async Task<IActionResult> UseCouponForTheOffer(int offerId)
        {
            if (!_offerService.OfferExists(offerId)) return NotFound();

            var response = await _offerService.UseCouponForTheOffer(offerId);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AddOfferDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create(AddOfferDto offer)
        {
            if (offer == null)
                return BadRequest(ModelState);

            if (_offerService.OfferExists(offer.Name))
            {
                ModelState.AddModelError("", "Offer exists!");
                return StatusCode(404, ModelState);
            }

            var response = await _offerService.Add(offer);

            return Ok(response);
        }
    }
}