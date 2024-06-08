using Core.Const;
using Core.Entity;
using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ProductEntity?> Add(AddProductRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _productService.AddProduct(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ProductEntity?> Update(string productCode, UpdateProductRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _productService.UpdateProduct(productCode, request);
            }
            return null;
        }

        [HttpPost]
        public async Task<ProductEntity?> ShowByProductCode(GetProductByCodeRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _productService.ShowByProductCode(request.ProductCode);
            }
            return null;
        }

        [HttpPost]
        public async Task<List<ProductEntity>?> ShowAll()
        {
            if(ModelState.IsValid)
            {
                return await _productService.ShowAll();
            }
            return null;
        }

        [HttpPost]
        public async Task<List<ProductEntity>?> ShowAllByCategory(CategoryEnum category)
        {
            if(ModelState.IsValid)
            {
                return await _productService.ShowAllByCategory(category);
            }
            return null;
        }

        [HttpDelete]
        public void Delete(string productCode)
        {
            if(ModelState.IsValid)
            {
                _productService.Delete(productCode);
            }
        }
    }
}
