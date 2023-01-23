using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;

        private readonly IMapper _mapper;
        public ProductRepository(MySqlContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductVO>> GetAllAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> GetByIdAsync(long id)
        {
            Product product = await _context.Products.FindAsync(id) ?? new Product();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> CreateAsync(ProductVO productVo)
        {
            Product product = _mapper.Map<Product>(productVo);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> UpdateAsync(ProductVO productVo)
        {
            Product product = _mapper.Map<Product>(productVo);
            _context.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                Product product = await _context.Products.FindAsync(id) ?? new Product();

                if (product.Id <= 0) {
                    return false;
                }

                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
