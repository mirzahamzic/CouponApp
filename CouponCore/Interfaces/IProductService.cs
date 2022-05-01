using CouponCore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CouponCore.Interfaces
{
    public interface IProductService
    {
        Task<GetProductDto> Add(AddProductDto product);

        Task<IEnumerable<GetProductDto>> GetAll(ProductSearchDto req);

        Task<GetProductDto> GetById(int id);

        bool ProductExists(int id);

        bool ProductExists(string name);
    }
}