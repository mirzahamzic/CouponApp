using CouponCore.Dtos;
using CouponCore.Dtos.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponCore.Interfaces
{
    public interface IOfferService
    {
        Task<GetOfferDto> Add(AddOfferDto product);
        Task<IEnumerable<GetOfferDto>> GetAll(OfferSearchDto req);
        Task<GetOfferDto> GetById(int id);
        bool OfferExists(int id);
        bool OfferExists(string name);
    }
}
