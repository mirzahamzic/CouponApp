using AutoMapper;
using CouponCore.Dtos;
using CouponCore.Entites;
using CouponCore.Interfaces;
using CouponData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponServices
{
    public class CouponService : ICouponService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CouponService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCouponDto>> GenerateCoupon(int offerId, int numberOfCoupons)
        {
            var couponList = new List<Coupon>();

            for (int i = 0; i <= numberOfCoupons; i++)
            {
                couponList.Add(new Coupon() { OfferId = offerId, SerialNumber = Guid.NewGuid() });
            }

            await _context.AddRangeAsync(couponList);
            _context.SaveChanges();

            var response = _mapper.Map<List<GetCouponDto>>(couponList);

            return response;
        }

        public async Task<IEnumerable<GetCouponDto>> GetAll(CouponSearchDto req)
        {
            var query = _context.Coupons.Include(c => c.Offer).ThenInclude(c => c.Product).AsQueryable();
            if (req.SerialNumber != null)
            {
                query = query
                    .Where(x => x.SerialNumber == Guid.Parse(req.SerialNumber))
                    .AsQueryable();
            }

            if (req.Limit != null)
            {
                query = query
                    .Skip((int)req.Limit)
                    .Take((int)req.PageSize)
                    .AsQueryable();
            }

            var dbCoupons = await query
                .Select(c => _mapper.Map<GetCouponDto>(c))
                .ToListAsync();

            return dbCoupons;
        }
    }
}