using AutoMapper;
using CouponCore.Dtos;
using CouponCore.Dtos.Offer;
using CouponCore.Entites;
using CouponCore.Helpers;
using CouponCore.Interfaces;
using CouponData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponServices
{
    public class OfferService : IOfferService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OfferService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOfferDto> Add(AddOfferDto offer)
        {
            if (_context.Offers.Any(o => o.Name == offer.Name))
                throw new ArgumentNullException($"Product '{offer.Name}' already exists.");

            var newOffer = _mapper.Map<Offer>(offer);

            await _context.Offers.AddAsync(newOffer);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetOfferDto>(newOffer);
        }

        public async Task<IEnumerable<GetOfferDto>> GetAll(OfferSearchDto req)
        {
            var query = _context.Offers
                .Include(o => o.Product)
                .Include(o => o.Coupons)
                .AsQueryable();

            if (req.ProductName != null)
            {
                query = query
                    .Where(x => x.Product.Name.ToLower().Contains(req.ProductName.ToLower()))
                    .AsQueryable();
            }

            if (req.Limit != null)
            {
                query = query
                    .Skip((int)req.Limit)
                    .Take((int)req.PageSize)
                    .AsQueryable();
            }

            if (req.IsActive != null)
            {
                query = query
                    .Where(x => (x.EndAt > DateTime.Today) == req.IsActive)
                    .AsQueryable();
            }

            var dbOffers = await query
                .Select(o => _mapper.Map<GetOfferDto>(o))
                .ToListAsync();

            return dbOffers;
        }

        public async Task<GetOfferDto> GetById(int id)
        {
            var dbOffer = await _context.Offers
                .Include(o => o.Product)
                .Include(o => o.Coupons)
                .FirstOrDefaultAsync(p => p.Id == id);

            var result = _mapper.Map<GetOfferDto>(dbOffer);
            return result;
        }

        public async Task<GetOfferDto> UseCouponForTheOffer(int id)
        {
            var dbOffer = await _context.Offers
                .Include(p => p.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            var dbCoupons = await _context.Coupons
                .Where(c => c.OfferId == id)
                .ToListAsync();

            if (dbCoupons == null)
                throw new ArgumentNullException(nameof(dbCoupons));

            var randomCoupon = GeneralHelperClass.GetRandomCoupon(dbCoupons);

            dbOffer.Coupons = new List<Coupon>() { randomCoupon };
            var result = _mapper.Map<GetOfferDto>(dbOffer);

            int deleted = await _context.Database.ExecuteSqlRawAsync($"delete from coupons where id = {randomCoupon.Id}");

            return result;
        }

        public bool OfferExists(int id)
        {
            return _context.Offers.Any(o => o.Id == id);
        }

        public bool OfferExists(string name)
        {
            return _context.Offers.Any(o => o.Name == name);
        }
    }
}