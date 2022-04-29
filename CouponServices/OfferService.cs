using CouponCore.Dtos;
using CouponCore.Dtos.Offer;
using CouponCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponServices
{
    public class OfferService : IOfferService
    {
        public Task<GetOfferDto> Add(AddOfferDto product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetOfferDto>> GetAll(OfferSearchDto req)
        {
            throw new NotImplementedException();
        }

        public Task<GetOfferDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool OfferExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool OfferExists(string name)
        {
            throw new NotImplementedException();
        }
    }
}
