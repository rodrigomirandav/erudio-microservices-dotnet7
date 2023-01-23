using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? 
                throw new ArgumentException(nameof(productRepository)); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> Get(long id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product.Id <= 0) {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Post(ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            ProductVO product = await _productRepository.CreateAsync(productVO);

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Put(ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            ProductVO product = await _productRepository.UpdateAsync(productVO);

            return Ok(product);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductVO>> Delete(long id)
        {
            bool result = await _productRepository.DeleteAsync(id);

            if (!result)
                return BadRequest();
            
            return Ok();
        }
    }
}
