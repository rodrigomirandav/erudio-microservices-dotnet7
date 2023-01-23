using GeekShopping.ProductAPI.Data.ValueObjects;

namespace GeekShopping.ProductAPI.Repository.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductVO>> GetAllAsync();
    Task<ProductVO> GetByIdAsync(long id);
    Task<ProductVO> CreateAsync(ProductVO productVo);
    Task<ProductVO> UpdateAsync(ProductVO productVo);
    Task<bool> DeleteAsync(long id);
}
