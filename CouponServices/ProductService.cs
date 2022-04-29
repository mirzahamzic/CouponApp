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
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductDto> Add(AddProductDto product)
        {
            if (_context.Products.Any(p => p.Name == product.Name))
                throw new ArgumentNullException($"Product '{product.Name}' already exists.");

            var newProduct = _mapper.Map<Product>(product);

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetProductDto>(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetAll(ProductSearchDto req)
        {
            var query = _context.Products.AsQueryable();
            if (req.Name != null)
            {
                query = query
                    .Where(x => x.Name.ToLower().Contains(req.Name.ToLower()))
                    .AsQueryable();
            }

            if (req.Limit != null)
            {
                query = query
                    .Skip((int)req.Limit)
                    .Take((int)req.PageSize)
                    .AsQueryable();
            }

            var dbProducts = await query
                .Select(p => _mapper.Map<GetProductDto>(p))
                .ToListAsync();

            return dbProducts;
        }

        public async Task<GetProductDto> GetById(int id)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            var result = _mapper.Map<GetProductDto>(dbProduct);
            return result;
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }

        public bool ProductExists(string name)
        {
            return _context.Products.Any(p => p.Name.ToLower() == name.ToLower());
        }
    }
}