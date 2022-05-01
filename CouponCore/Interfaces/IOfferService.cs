using CouponCore.Dtos;
using CouponCore.Dtos.Offer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CouponCore.Interfaces
{
    public interface IOfferService
    {
        Task<GetOfferDto> Add(AddOfferDto product);

        Task<IEnumerable<GetOfferDto>> GetAll(OfferSearchDto req);

        Task<GetOfferDto> GetById(int id);

        Task<GetOfferDto> UseCouponForTheOffer(int id);

        bool OfferExists(int id);

        bool OfferExists(string name);
    }
}